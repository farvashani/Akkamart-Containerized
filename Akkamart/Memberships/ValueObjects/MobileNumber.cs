using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Memberships {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class MobileNumber : SingleValueObject<string> {
        public MobileNumber (string value) : base (value) { }
    }
}