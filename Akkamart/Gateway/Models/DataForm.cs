using System.Collections.Generic;

namespace Gateway.Models
{
    public class DataForm
    {
        public string Title { get; set; }
        public IList<FormElement>   Elements { get; set; }


    }
}