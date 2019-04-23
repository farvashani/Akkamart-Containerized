using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Orders {
    public class OrderManager
        : AggregateManager<Order, OrderId, Command<Order, OrderId>> {

        }
}