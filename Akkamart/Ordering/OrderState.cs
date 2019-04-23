using Akkatecture.Aggregates;

namespace Orders {
    public class OrderState
        : AggregateState<Order, OrderId> {
            public OrderState () { }
        }

}