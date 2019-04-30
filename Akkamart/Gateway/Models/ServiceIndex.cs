using System.Collections.Generic;

namespace Gateway.Models {
    public class ServiceIndex {
        public string Title { get; set; }
        public IList<ServiceAction> Actions { get; set; }
    }
}