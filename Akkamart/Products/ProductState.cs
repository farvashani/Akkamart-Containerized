using Akkatecture.Aggregates;

namespace Products {
    public class ProductState
        : AggregateState<Product, ProductId> {
            public ProductState () { }
        }

}