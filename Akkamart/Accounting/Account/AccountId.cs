using Akkatecture.Core;
using Akkatecture.ValueObjects;
using Newtonsoft.Json;

namespace Accounting {
    [JsonConverter (typeof (SingleValueObjectConverter))]
    public class AccountId : Identity<AccountId> {
        public AccountId (string value) : base (value) { }
    }
}