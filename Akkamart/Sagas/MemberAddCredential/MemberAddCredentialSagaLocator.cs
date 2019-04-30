using System;
using Accounting;
using Akkatecture.Aggregates;
using Akkatecture.Sagas;

namespace Sagas.MemberAddCredential {
    public class MemberAddCredentialSagaLocator : ISagaLocator<MemberAddCredentialSagaId> {
        public const string LocatorIdPrefix = "memberaddcredential";

        public MemberAddCredentialSagaId LocateSaga (IDomainEvent domainEvent) {
            switch (domainEvent.GetAggregateEvent ()) {
                case MoneySentEvent evt:
                    return new MemberAddCredentialSagaId ($"{LocatorIdPrefix}-{evt.Transaction.Id}");

                case MoneyReceivedEvent evt:
                    return new MemberAddCredentialSagaId ($"{LocatorIdPrefix}-{evt.Transaction.Id}");

                default:
                    throw new ArgumentException (nameof (domainEvent));
            }
        }
    }
}