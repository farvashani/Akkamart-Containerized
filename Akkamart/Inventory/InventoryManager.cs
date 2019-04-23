using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Inventory {
    public class InventoryManager
        : AggregateManager<Inventory, InventoryId, Command<Inventory, InventoryId>> {

        }
}