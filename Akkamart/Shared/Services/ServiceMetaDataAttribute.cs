using System;

namespace Shared.Services {
    public class ServiceMetaDataAttribute : Attribute {
        public ServiceMetaDataAttribute (string name) {
            this.Name = name;

        }
        public string Name { get; private set; }

    }
}