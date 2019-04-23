using Akkatecture.Aggregates;

namespace Products {
    public class Product : AggregateRoot<Product, ProductId, ProductState> {
        public Product (ProductId id) : base (id) { }
    }
}