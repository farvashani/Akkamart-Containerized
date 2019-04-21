using System;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Memberships {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class LastUnSuccessFullLoginAttempt : SingleValueObject<DateTime> {
        public LastUnSuccessFullLoginAttempt (DateTime value) : base (value) { }
    }
}