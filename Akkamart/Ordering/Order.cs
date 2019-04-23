using Akkatecture.Aggregates;

namespace Orders {
    public class Order
        : AggregateRoot<Order, OrderId, OrderState> {
            public Order (OrderId id) : base (id) { }
        }
}