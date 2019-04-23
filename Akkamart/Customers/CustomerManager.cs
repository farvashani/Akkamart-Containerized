using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Customers {
    public class CustomerManager
        : AggregateManager<Customer, CustomerId, Command<Customer, CustomerId>> {

        }
}