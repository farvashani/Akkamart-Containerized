using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Catalogs {
    public class CatalogManager : AggregateManager<Catalog, CatalogId, Command<Catalog, CatalogId>> {
        public CatalogManager () { }
    }
}