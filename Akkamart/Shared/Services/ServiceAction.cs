using System;
using System.Collections.Generic;
namespace Shared.Services {
    public class ServiceAction {
        public string Title { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Type> Params { get; set; }

    }
}