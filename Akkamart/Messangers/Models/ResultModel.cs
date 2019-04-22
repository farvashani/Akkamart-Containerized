using System;

namespace Messangers {
    public class ResultModel {
        public Return @return { get; set; }
        public Entry[] entries { get; set; }

    }

    public class Return {
        public int status { get; set; }
        public string message { get; set; }

    }

    public class Entry {
        public long messageid { get; set; }
        public string statustext { get; set; }
        public int status { get; set; }
        public string sender { get; set; }
        public string receptor { get; set; }
        //public DateTime date { get; set; }
        public int cost { get; set; }
    }
}