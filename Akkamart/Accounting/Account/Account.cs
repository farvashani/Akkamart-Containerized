using Akkatecture.Aggregates;
using Akkatecture.Extensions;
using Akkatecture.Specifications.Provided;

namespace Accounting {
    public class Account : AggregateRoot<Account, AccountId, AccountState> {
        public Account (AccountId aggregateId) : base (aggregateId) {
            Command<OpenNewAccountCommand> (Execute);
            Command<TransferMoneyCommand> (Execute);
            Command<ReceiveMoneyCommand> (Execute);
        }

        private bool Execute (OpenNewAccountCommand command) {
            //this spec is part of Akkatecture
            var spec = new AggregateIsNewSpecification ();
            if (spec.IsSatisfiedBy (this)) {
                var aggregateEvent = new AccountOpenedEvent (command.OpeningBalance);
                Emit (aggregateEvent);
            }

            return true;
        }

        private bool Execute (TransferMoneyCommand command) {
            var balanceSpec = new EnoughBalanceAmountSpecification ();
            var minimumTransferSpec = new MinimumTransferAmountSpecification ();

            var andSpec = balanceSpec.And (minimumTransferSpec);

            if (andSpec.IsSatisfiedBy (this)) {
                var sentEvent = new MoneySentEvent (command.Transaction);
                Emit (sentEvent);

                var feeEvent = new FeesDeductedEvent (new Money (0.25m));
                Emit (feeEvent);
            }

            return true;
        }

        private bool Execute (ReceiveMoneyCommand command) {
            var moneyReceived = new MoneyReceivedEvent (command.Transaction);

            Emit (moneyReceived);
            return true;
        }
    }
}