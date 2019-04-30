using System.Threading.Tasks;
using Accounting;
using Akka.Actor;
using Akkatecture.Aggregates;
using Akkatecture.Extensions;
using Akkatecture.Sagas;
using Akkatecture.Sagas.AggregateSaga;
using Akkatecture.Specifications.Provided;
using Sagas.Events;
using Memberships;

namespace Sagas.MemberAddCredential
{
    public class MemberAddCredentialSaga : AggregateSaga<MemberAddCredentialSaga, MemberAddCredentialSagaId, MemberAddCredentialSagaState>,
        ISagaIsStartedBy<MemberAggregate, MemberId, MemberAddCredentialEvent>
    // ,ISagaHandles<Account, AccountId, MoneyReceivedEvent> 
    {
        public IActorRef MemberManager { get; }
        public IActorRef CredentialManager { get; }
        public MemberAddCredentialSaga(IActorRef memberManager, IActorRef credentialManager)
        {
            MemberManager = memberManager;
            CredentialManager = credentialManager;
        }
        public bool Handle(IDomainEvent<MemberAggregate, MemberId, MemberAddCredentialEvent> domainEvent)
        {
            var isNewSpec = new AggregateIsNewSpecification();
            if (isNewSpec.IsSatisfiedBy(this))
            {
                //Call Credential

                // var command = new ReceiveMoneyCommand (
                //     domainEvent.AggregateEvent.Transaction.Receiver,
                //     domainEvent.AggregateEvent.Transaction);

                // AccountAggregateManager.Tell (command);


                //For Apply State
                // Emit (new MemberAddCredentialStartedEvent (domainEvent.AggregateEvent.Transaction));
            }

            return true;
        }

        // public bool Handle (IDomainEvent<Account, AccountId, MoneyReceivedEvent> domainEvent) {
        //     var spec = new AggregateIsNewSpecification ().Not ();
        //     if (spec.IsSatisfiedBy (this)) {
        //         Emit (new MemberAddCredentialCompletedEvent (domainEvent.AggregateEvent.Transaction));
        //     }

        //     return true;
        // }
    }
}