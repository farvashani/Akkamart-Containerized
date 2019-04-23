using System;
using Accounting;
using Akkatecture.Aggregates;
using Akkatecture.Sagas;

namespace Sagas {
    public class MoneyTransferSagaLocator : ISagaLocator<MoneyTransferSagaId> {
        public const string LocatorIdPrefix = "moneytransfer";

        public MoneyTransferSagaId LocateSaga (IDomainEvent domainEvent) {
            switch (domainEvent.GetAggregateEvent ()) {
                case MoneySentEvent evt:
                    return new MoneyTransferSagaId ($"{LocatorIdPrefix}-{evt.Transaction.Id}");

                case MoneyReceivedEvent evt:
                    return new MoneyTransferSagaId ($"{LocatorIdPrefix}-{evt.Transaction.Id}");

                default:
                    throw new ArgumentException (nameof (domainEvent));
            }
        }
    }
}