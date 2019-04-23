using Akkatecture.Sagas;

namespace Sagas {
    public class MoneyTransferSagaId : SagaId<MoneyTransferSagaId> {
        public MoneyTransferSagaId (string value) : base (value) { }
    }
}