using Akkatecture.Aggregates;

namespace Marketing {
    public class Marketing
        : AggregateRoot<Marketing, MarketingId, MarketingState> {
            public Marketing (MarketingId id) : base (id) { }
        }
}