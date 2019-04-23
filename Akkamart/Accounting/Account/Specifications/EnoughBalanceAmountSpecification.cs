using System.Collections.Generic;
using Akkatecture.Specifications;

namespace Accounting {
    public class EnoughBalanceAmountSpecification : Specification<Account> {
        protected override IEnumerable<string> IsNotSatisfiedBecause (Account account) {
            if (account.State.Balance.Value < 1.25m) {
                yield return $"'Balance for Account: {account.Id} is {account.State.Balance.Value}' is lower than 1.25";
            }
        }
    }
}