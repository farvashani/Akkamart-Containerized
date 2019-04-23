using Akkatecture.Core;

namespace Customers {
    public class CustomerId : Identity<CustomerId> {

        public CustomerId (string value) : base (value) { }
    }
}