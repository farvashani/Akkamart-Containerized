using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Accounting {
    [EventVersion ("FeesDeducted", 1)]
    public class FeesDeductedEvent : AggregateEvent<Account, AccountId> {
        public Money Amount { get; }

        public FeesDeductedEvent (Money amount) {
            Amount = amount;
        }
    }
}