using System.Collections.Generic;
using Akkatecture.Specifications;

namespace Accounting {
    public class MinimumTransferAmountSpecification : Specification<Account> {
        protected override IEnumerable<string> IsNotSatisfiedBecause (Account account) {
            if (account.State.Balance.Value < 1.00m) {
                yield return $"'{account.State.Balance.Value}' is lower than 1.25 '{account.GetIdentity()}' is not new";
            }
        }
    }
}