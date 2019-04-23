using Akkatecture.Aggregates;

namespace Catalogs {
    public class Catalog : AggregateRoot<Catalog, CatalogId, CatalogState>
    {
        public Catalog(CatalogId id) : base(id)
        {
        }
    }
}