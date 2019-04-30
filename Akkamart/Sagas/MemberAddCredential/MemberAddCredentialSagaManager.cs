using System;
using System.Linq.Expressions;
using Akkatecture.Sagas.AggregateSaga;

namespace Sagas.MemberAddCredential {
    public class MemberAddCredentialSagaManager:
        AggregateSagaManager<MemberAddCredentialSaga, MemberAddCredentialSagaId, MemberAddCredentialSagaLocator> {
            public MemberAddCredentialSagaManager (Expression<Func<MemberAddCredentialSaga>> factory) : base (factory) { }
        }
}