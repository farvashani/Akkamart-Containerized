using System;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Memberships {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class LastSuccessfullLogin : SingleValueObject<DateTime> {
        public LastSuccessfullLogin (DateTime value) : base (value) { }
    }
}