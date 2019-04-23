using Akkatecture.Core;

namespace Orders {
    public class OrderId : Identity<OrderId> {

        public OrderId (string value) : base (value) { }

    }
}