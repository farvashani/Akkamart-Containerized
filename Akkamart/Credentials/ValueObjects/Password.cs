using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Credentials {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Password : SingleValueObject<string> {
        public Password (string value) : base (value) { }
    }
}