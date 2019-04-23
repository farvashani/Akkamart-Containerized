using Accounting;
using Akkatecture.Aggregates;
using Akkatecture.Sagas;
using Sagas.Events;

namespace Sagas {
    public class MoneyTransferSagaState : SagaState<MoneyTransferSaga, MoneyTransferSagaId, IMessageApplier<MoneyTransferSaga, MoneyTransferSagaId>>,
        IApply<MoneyTransferStartedEvent>,
        IApply<MoneyTransferCompletedEvent> {
            public Transaction Transaction { get; private set; }
            public void Apply (MoneyTransferStartedEvent aggregateEvent) {
                Transaction = aggregateEvent.Transaction;
                Start ();
            }

            public void Apply (MoneyTransferCompletedEvent aggregateEvent) {
                Complete ();
            }
        }
}