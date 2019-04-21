using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Credentials {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Username : SingleValueObject<string> {
        public Username (string value) : base (value) { }
    }
}