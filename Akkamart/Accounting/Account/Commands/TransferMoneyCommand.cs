using System;
using Akkatecture.Commands;

namespace Accounting {
    public class TransferMoneyCommand : Command<Account, AccountId> {
        public Transaction Transaction { get; }
        public TransferMoneyCommand (
            AccountId aggregateId,
            Transaction transaction) : base (aggregateId) {
            if (transaction == null) throw new ArgumentNullException (nameof (transaction));
            if (transaction.Sender != AggregateId) throw new ArgumentException ($"{nameof(Transaction.Sender)} should be the same as {nameof(AggregateId)}.");

            Transaction = transaction;
        }
    }
}