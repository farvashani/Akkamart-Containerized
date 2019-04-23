using System;
using Akkatecture.Commands;

namespace Accounting {
    public class OpenNewAccountCommand : Command<Account, AccountId> {
        public Money OpeningBalance { get; }

        public OpenNewAccountCommand (
            AccountId aggregateId,
            Money openingBalance) : base (aggregateId) {
            if (openingBalance == null) throw new ArgumentNullException (nameof (openingBalance));

            OpeningBalance = openingBalance;
        }
    }
}