using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Domain.Membership.Core.ValueObjects
{
    
     [JsonConverter(typeof(SingleValueObjectConverter))]
    public class IsCredentialRequested : SingleValueObject<bool>
    {
        public IsCredentialRequested(bool value) : base(value)
        {
        }
    }
}