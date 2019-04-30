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
using Credentials;
using Akka.Routing;

namespace Sagas.MemberAddCredential
{
    public class MemberAddCredentialSaga : AggregateSaga<MemberAddCredentialSaga, MemberAddCredentialSagaId, MemberAddCredentialSagaState>,
        ISagaIsStartedBy<MemberAggregate, MemberId, MemberAddCredentialEvent>
    // ,ISagaHandles<Account, AccountId, MoneyReceivedEvent> 
    {
        public IActorRef MembershipService { get; private set; }
        public IActorRef CredentialService { get; private set; }
        public MemberAddCredentialSaga()
        {
            MembershipService = Context.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), nameof(MemberManager).ToLower());
            CredentialService = Context.ActorOf(Props.Empty.WithRouter(FromConfig.Instance), nameof(CredentialManager).ToLower());
        }
        public bool Handle(IDomainEvent<MemberAggregate, MemberId, MemberAddCredentialEvent> domainEvent)
        {
            var isNewSpec = new AggregateIsNewSpecification();
            if (isNewSpec.IsSatisfiedBy(this))
            {
                //Call Credential
                var credentialId = CredentialId.New;
                var command = new Credentials.StoreCredential(credentialId,domainEvent.AggregateEvent.MemberId,domainEvent.AggregateEvent.Username.Value,domainEvent.AggregateEvent.Password.Value);

                CredentialService.Tell(command);


                // For Apply State
                //Emit (new MemberAddCredentialStartedEvent (domainEvent.AggregateEvent.Transaction));
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