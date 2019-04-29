using Accounting;
using Akkatecture.Aggregates;
using Akkatecture.Sagas;
using Sagas.Events;

namespace Sagas.MemberAddCredential {
    public class MemberAddCredentialSagaState : SagaState<MemberAddCredentialSaga, MemberAddCredentialSagaId, IMessageApplier<MemberAddCredentialSaga, MemberAddCredentialSagaId>>
        // IApply<MemberAddCredentialStartedEvent>,
        // IApply<MemberAddCredentialCompletedEvent> 
        {
            // public Transaction Transaction { get; private set; }
            // public void Apply (MemberAddCredentialStartedEvent aggregateEvent) {
            //     Transaction = aggregateEvent.Transaction;
            //     Start ();
            // }

            // public void Apply (MemberAddCredentialCompletedEvent aggregateEvent) {
            //     Complete ();
            // }
        }
}