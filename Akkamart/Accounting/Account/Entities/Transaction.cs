using System;
using Akkatecture.Entities;

namespace Accounting {
    public class Transaction : Entity<TransactionId> {
        public AccountId Sender { get; }
        public AccountId Receiver { get; }
        public Money Amount { get; }

        public Transaction (
            TransactionId entityId,
            AccountId sender,
            AccountId receiver,
            Money amount) : base (entityId) {
            if (sender == null) throw new ArgumentNullException (nameof (sender));
            if (receiver == null) throw new ArgumentNullException (nameof (receiver));
            if (amount == null) throw new ArgumentNullException (nameof (amount));
            if (sender == receiver) throw new ArgumentException ($"{nameof(Sender)} should be the same as {nameof(Receiver)}.");

            Sender = sender;
            Receiver = receiver;
            Amount = amount;
        }

        public Transaction (
            AccountId sender,
            AccountId receiver,
            Money amount) : this (TransactionId.New, sender, receiver, amount) { }
    }
}