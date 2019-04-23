using System;
using System.Linq.Expressions;
using Akkatecture.Sagas.AggregateSaga;

namespace Sagas {
    public class MoneyTransferSagaManager:
        AggregateSagaManager<MoneyTransferSaga, MoneyTransferSagaId, MoneyTransferSagaLocator> {
            public MoneyTransferSagaManager (Expression<Func<MoneyTransferSaga>> factory) : base (factory) { }
        }
}