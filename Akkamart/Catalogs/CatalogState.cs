using Akkatecture.Aggregates;

namespace Catalogs {
    public class CatalogState : AggregateState<Catalog, CatalogId> {
        public CatalogState () { }
    }
}