using System;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Messangers {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class SendingDate : SingleValueObject<DateTime> {
        public SendingDate (DateTime value) : base (value) { }
    }
}