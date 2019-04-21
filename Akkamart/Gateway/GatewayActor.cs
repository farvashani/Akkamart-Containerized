﻿using System;
using Akka.Actor;
using Akka.Event;
using Akka.Routing;
using Shared;

namespace Gateway {
    public class GatewayActor : ReceiveActor {
        private readonly ILoggingAdapter _log = Context.GetLogger ();

        public GatewayActor () {
            Console.Write ("Gateway Startup......");

            MembershipService = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
                MyActorNames.MembershipActorname);

            CredentialService = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
                MyActorNames.CredentialActorname);

            MessangerService = Context.ActorOf (Props.Empty.WithRouter (FromConfig.Instance),
                MyActorNames.SmsServiceActorname);
            //var i = 1;
            Receive<ReceiveTimeout> (t => {
                // _log.Info ("Tick..");
                // membership.Tell (new WorkItem { Id = i, Name = $"Work-{DateTime.Now.TimeOfDay}" });

                // sms.Tell (new WorkItem { Id = i, Name = $"Work-{DateTime.Now.TimeOfDay}" });
                // i++;
            });
        }

        public IActorRef MembershipService { get; private set; }
        public IActorRef CredentialService { get; private set; }
        public IActorRef MessangerService { get; private set; }

        protected override void PreStart () {
            _log.Info ("Startup actor starting..");
            SetReceiveTimeout (TimeSpan.FromSeconds (3));
        }

    }
}