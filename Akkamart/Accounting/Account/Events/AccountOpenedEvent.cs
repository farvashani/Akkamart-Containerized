using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Accounting {
    [EventVersion ("AccountOpened", 1)]
    public class AccountOpenedEvent : AggregateEvent<Account, AccountId> {
        public Money OpeningBalance { get; }

        public AccountOpenedEvent (Money openingBalance) {
            OpeningBalance = openingBalance;
        }

    }
}