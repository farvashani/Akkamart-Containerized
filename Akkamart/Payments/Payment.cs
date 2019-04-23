using Akkatecture.Aggregates;

namespace Payments {
    public class Payment
        : AggregateRoot<Payment, PaymentId, PaymentState> {
            public Payment (PaymentId id) : base (id) { }
        }
}