using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Memberships {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class FullName : SingleValueObject<string> {
        public FullName (string value) : base (value) { }
    }
}