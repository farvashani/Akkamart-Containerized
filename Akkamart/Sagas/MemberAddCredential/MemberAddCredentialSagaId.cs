using Akkatecture.Sagas;

namespace Sagas.MemberAddCredential
{
    public class MemberAddCredentialSagaId : SagaId<MemberAddCredentialSagaId>
    {
        public MemberAddCredentialSagaId(string value) : base(value)
        {
        }
    }
}