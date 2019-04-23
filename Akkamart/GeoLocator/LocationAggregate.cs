using Akkatecture.Aggregates;

namespace GeoLocator {
    public class LocationAggregate 
    : AggregateRoot<LocationAggregate, LocationId, LocationState>
    {
        public LocationAggregate(LocationId id) : base(id)
        {
        }
    }
}