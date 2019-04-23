using Akkatecture.Aggregates;

namespace Inventory {
    public class InventoryState
        : AggregateState<Inventory, InventoryId> {
            public InventoryState () { }
        }

}