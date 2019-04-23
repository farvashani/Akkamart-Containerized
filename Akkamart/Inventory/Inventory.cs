using Akkatecture.Aggregates;

namespace Inventory {
    public class Inventory
        : AggregateRoot<Inventory, InventoryId, InventoryState> {
            public Inventory (InventoryId id) : base (id) { }
        }
}