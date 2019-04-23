using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Payments {
    public class PaymentManager
        : AggregateManager<Payment, PaymentId, Command<Payment, PaymentId>> {

        }
}