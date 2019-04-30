using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Akkatecture.Aggregates;
using Akkatecture.Commands;
using Akkatecture.Core;

namespace Shared.Services {
    public class MetaDataExtractor<TAggregate, TIdentity>
        where TAggregate : IAggregateRoot<TIdentity>
        where TIdentity : IIdentity {
            public virtual ServiceMetadata Extract (Assembly assembly) {
                var serviceType = assembly.GetTypes ().Where (t =>
                    t.GetCustomAttributes<ServiceMetaDataAttribute> ().Any ());

                var commandTypes = serviceType.GetType ().Assembly.GetTypes ().Where (t => t.BaseType != null && t.BaseType.IsGenericType &&
                    t.BaseType.GetGenericTypeDefinition () == typeof (ICommand<TAggregate, TIdentity>));

                var serviceMetadata = new ServiceMetadata ();
                serviceMetadata.Title = typeof (TAggregate).Name;

                foreach (var cmd in commandTypes) {
                    var action = new ServiceAction () { Title = cmd.Name };
                    action.Params = getParams (cmd);

                }
                return serviceMetadata;

            }

            private Dictionary<string, Type> getParams (Type cmd) {
                var paramsDict = new Dictionary<string, Type> ();
                var ctor = cmd.GetConstructors ().OrderBy (np => np.GetParameters ().Count ()).FirstOrDefault ();
                var constParams = ctor.GetParameters ();
                foreach (var p in constParams) {
                    paramsDict.Add (p.GetType ().Name, p.GetType ());

                }
                return paramsDict;

            }
        }
}