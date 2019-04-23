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

            var gatewayActor = sys.ActorOf<GatewayActor> (MyActorNames.Gateway);
            var startupActor = sys.ActorOf<GatewayStartup> (MyActorNames.Gateway);

            services
                .AddAkkatecture (sys)
                .AddActorReference<GatewayActor> (gatewayActor);

        }

    }
}