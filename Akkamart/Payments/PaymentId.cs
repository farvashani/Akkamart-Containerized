using Akkatecture.Core;

namespace Payments {
    public class PaymentId : Identity<PaymentId> {

        public PaymentId (string value) : base (value) { }

    }
}