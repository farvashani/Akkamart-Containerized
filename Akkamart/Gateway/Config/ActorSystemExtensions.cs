using System;
using Akka.Actor;
using Akka.Routing;
using Microsoft.Extensions.DependencyInjection;
using Shared;

namespace Gateway {
    public static class ActorSystemExtensions {
        public static void AddMicroservice (this IServiceCollection services, string confUrl) {
            if (confUrl == null)
                confUrl = "Gateway.conf";

            var sys = Common.CreateSystem (confUrl);

            sys.ActorOf<GatewayStartup> (MyActorNames.Gateway);

        }

    }
}