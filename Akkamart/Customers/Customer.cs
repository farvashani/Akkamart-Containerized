using Akkatecture.Aggregates;

namespace Customers {
    public class Customer : AggregateRoot<Customer, CustomerId, CustomerState>
    {
        public Customer(CustomerId id) : base(id)
        {
        }
    }
}