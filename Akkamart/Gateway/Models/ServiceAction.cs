using System;

namespace Gateway.Models {
    public class ServiceAction {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DataForm Form { get; set; }
        public DataList Data { get; set; }
    }
}