using System.Collections.Generic;
using System.Security.AccessControl;
namespace Shared.Services {
    public class ServiceMetadata {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }

        public IList<ServiceAction> Actions { get; set; }
    }
}