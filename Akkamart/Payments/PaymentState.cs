using Akkatecture.Aggregates;

namespace Payments {
    public class PaymentState
        : AggregateState<Payment, PaymentId> {
            public PaymentState () { }
        }

}