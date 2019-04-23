using System.Threading.Tasks;
using Accounting;
using Akka.Actor;
using Akkatecture.Aggregates;
using Akkatecture.Extensions;
using Akkatecture.Sagas;
using Akkatecture.Sagas.AggregateSaga;
using Akkatecture.Specifications.Provided;
using Sagas.Events;

namespace Sagas {
    public class MoneyTransferSaga : AggregateSaga<MoneyTransferSaga, MoneyTransferSagaId, MoneyTransferSagaState>,
        ISagaIsStartedBy<Account, AccountId, MoneySentEvent>,
        ISagaHandles<Account, AccountId, MoneyReceivedEvent> {
            public IActorRef AccountAggregateManager { get; }
            public MoneyTransferSaga (IActorRef accountAggregateManager) {
                AccountAggregateManager = accountAggregateManager;
            }
            public bool Handle (IDomainEvent<Account, AccountId, MoneySentEvent> domainEvent) {
                var isNewSpec = new AggregateIsNewSpecification ();
                if (isNewSpec.IsSatisfiedBy (this)) {
                    var command = new ReceiveMoneyCommand (
                        domainEvent.AggregateEvent.Transaction.Receiver,
                        domainEvent.AggregateEvent.Transaction);

                    AccountAggregateManager.Tell (command);

                    Emit (new MoneyTransferStartedEvent (domainEvent.AggregateEvent.Transaction));
                }

                return true;
            }

            public bool Handle (IDomainEvent<Account, AccountId, MoneyReceivedEvent> domainEvent) {
                var spec = new AggregateIsNewSpecification ().Not ();
                if (spec.IsSatisfiedBy (this)) {
                    Emit (new MoneyTransferCompletedEvent (domainEvent.AggregateEvent.Transaction));
                }

                return true;
            }
        }
}