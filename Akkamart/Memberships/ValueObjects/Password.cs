using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Memberships {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Password : SingleValueObject<string> {
        public Password (string value) : base (value) { }
    }
}