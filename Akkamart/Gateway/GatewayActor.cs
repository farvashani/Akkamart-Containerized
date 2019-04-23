using System;
using Akka.Actor;
using Akka.Event;
using Akka.Routing;
using Memberships;
using Shared;

namespace Gateway {
    public class GatewayActor : ReceiveActor {
        public IActorRef MembershipService { get; private set; }
        public IActorRef CredentialService { get; private set; }
        public IActorRef MessangerService { get; private set; }
        public IActorRef AccountingActor { get; private set; }
        public IActorRef CatalogsActor { get; private set; }
        public IActorRef CustomersActor { get; private set; }
        public IActorRef GeoLocatorActor { get; private set; }
        public IActorRef InventoryActor { get; private set; }
        public IActorRef MarketingActor { get; private set; }
        public IActorRef OrderingActor { get; private set; }
        public IActorRef PaymentsActor { get; private set; }
        public IActorRef PointsServiceActor { get; private set; }
        private readonly ILoggingAdapter _log = Context.GetLogger ();

        public GatewayActor () {
            Console.Write ("Gateway Startup......");

            MembershipService = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
                nameof (MemberManager).ToLower ());

            CredentialService = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
                MyActorNames.CredentialActorname);

            MessangerService = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
                MyActorNames.SmsServiceActorname);

            // AccountingActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.AccountingActorname);

            // CatalogsActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.CatalogsSActorname);

            // CustomersActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.CustomersActorname);

            // GeoLocatorActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.GeoLocatorActorname);

            // InventoryActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.InventoryActorname);

            // MarketingActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.MarketingActorname);

            // OrderingActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.OrderingActorname);

            // PaymentsActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.PaymentsActorname);

            // PointsServiceActor = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.PointsActorname);

            Receive<AddMember> (t => {

                var memerId = Memberships.MemberId.New;
                var cmd = new Memberships.CreateMemberCommand (memerId, t.Mobilenumber);
                MembershipService.Tell (cmd);
                //         MembershipService.Ask<MemberAddedEvent> (t).ContinueWith (r => {
                //             return new MemberAddedEvent (r.Result.MemberId, r.Result.IsSucceed);
                //             }).PipeTo (Self);

                });

             }

            protected override void PreStart () {
                _log.Info ("Startup actor starting..");
                SetReceiveTimeout (TimeSpan.FromSeconds (3));
            }
        }

    }