using System;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Memberships {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class CreationDate : SingleValueObject<DateTime> {

        public CreationDate (string date = null) : base (date == null ?
            DateTime.Parse (date) :
            DateTime.Parse (date)) {
            var value = date == null ?
                DateTime.Parse (date) :
                DateTime.Parse (date);

        }
        public CreationDate (DateTime value) : base (value) { }
        // public CreationDate(string value) 
        // {
        //     CreationDate(DateTime.Now);
        // }
    }
}