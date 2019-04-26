using System;
using Akka.Actor;
using Akka.Actor.Dsl;
using Akka.Event;
using Akka.Routing;
using Memberships;
using Shared;

namespace Gateway {
    public class GatewayActor : ReceiveActor {

        public IActorRef SenderController { get; private set; }
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
            var members = Context.ActorOf (Props.Create<MembershipsActor> (),
                nameof (Memberships).ToLower ());

            // CredentialService = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.CredentialActorname);

            // MessangerService = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
            //     MyActorNames.SmsServiceActorname);

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

            Receive<MemberCreatedEvent> (e => {
                SenderController.Tell(new MemberAddedEvent(e.MemberId.Value, e.IsSucceed));

            });

            Receive<AddMember> (t => {
                SenderController = Sender;
                var memberId = MemberId.New;
                var cmd = new Memberships.CreateMemberCommand (memberId, t.Mobilenumber);
                members.Ask<MemberCreatedEvent> (cmd)
                    .ContinueWith (r => {

                        if (r.Result.IsSucceed) {
                        return new MemberCreatedEvent (r.Result.Mobilenumber, r.Result.MemberId,
                        r.Result.IsSucceed);
                        } else {
                        return new MemberCreatedEvent (r.Result.Mobilenumber, r.Result.MemberId,
                        r.Result.IsSucceed);
                        }

                    }).PipeTo (Self);

                //Sender.Tell (new MemberAddedEvent (memberId.Value, true));

                // var memerId = Memberships.MemberId.New;
                // // 
                // // MembershipService.Tell (cmd);
                // //         MembershipService.Ask<MemberAddedEvent> (t).ContinueWith (r => {
                // //             return new MemberAddedEvent (r.Result.MemberId, r.Result.IsSucceed);
                // //             }).PipeTo (Self);
                // // members.Ask<MemberAddedEvent> (new WorkItem ()).ContinueWith (r => {
                // //     if (r.Result.IsSucceed) {
                // //         var mae = new MemberAddedEvent (memerId.Value, r.Result.IsSucceed);
                // //         return mae;

                // //     } else {
                // //         var mae2 = new MemberAddedEvent (memerId.Value, r.Result.IsSucceed);
                // //         return mae2;
                // //     }

                // // }).PipeTo (Sender);

            });

        }

        protected override void PreStart () {
            _log.Info ("Startup actor starting..");
            SetReceiveTimeout (TimeSpan.FromSeconds (3));
        }
    }

}