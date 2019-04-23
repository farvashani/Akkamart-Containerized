using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Accounting {
    [EventVersion ("MoneySent", 1)]
    public class MoneySentEvent : AggregateEvent<Account, AccountId> {
        public Transaction Transaction { get; }

        public MoneySentEvent (Transaction transaction) {
            Transaction = transaction;
        }
    }
}