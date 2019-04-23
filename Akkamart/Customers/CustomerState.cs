using Akkatecture.Aggregates;

namespace Customers {
    public class CustomerState : AggregateState<Customer, CustomerId>
    {
        public CustomerState()
        {
        }
    }
}