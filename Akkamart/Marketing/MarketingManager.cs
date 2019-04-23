using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Marketing {
    public class MarketingManager : AggregateManager<Marketing, MarketingId, Command<Marketing, MarketingId>> { }
}