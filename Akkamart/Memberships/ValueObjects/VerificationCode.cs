using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Memberships {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class VerificationCode : SingleValueObject<string> {
        public VerificationCode (string value) : base (value) { }
    }
}