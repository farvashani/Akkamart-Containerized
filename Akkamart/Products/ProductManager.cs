using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Products {
    public class ProductManager
        : AggregateManager<Product, ProductId, Command<Product, ProductId>> {

        }
}