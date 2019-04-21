using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Memberships {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class IsVerified : SingleValueObject<bool> {
        public IsVerified (bool value) : base (value) { }
    }
}