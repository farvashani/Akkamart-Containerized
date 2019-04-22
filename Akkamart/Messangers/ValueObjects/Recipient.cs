using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Messangers {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class Recipient : SingleValueObject<string> {
        public Recipient (string value) : base (value) { }
    }

}