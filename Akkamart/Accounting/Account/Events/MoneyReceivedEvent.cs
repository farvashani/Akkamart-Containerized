using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Accounting {
    [EventVersion ("MoneyReceived", 1)]
    public class MoneyReceivedEvent : AggregateEvent<Account, AccountId> {
        public Transaction Transaction { get; }

        public MoneyReceivedEvent (Transaction transaction) {
            Transaction = transaction;
        }
    }
}