using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Messangers
{
    [JsonConverter(typeof(SingleValueObjectConverter))]
    public class MessageBody : SingleValueObject<string>
    {
        public MessageBody(string value) : base(value)
        {
        }
    }


}