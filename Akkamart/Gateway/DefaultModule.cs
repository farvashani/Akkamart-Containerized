using System;
using System.IO;
using System.Linq;
using Autofac;
using Shared.Services;

namespace Gateway {
    public class DefaultModule : Module {
        protected override void Load (ContainerBuilder builder) {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies ()
                .Where (a => a.GetTypes ().Any(t => t.GetCustomAttributes<ServiceMetaDataAttribute>() != null));

                }
        }
    }