using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace GeoLocator {
    public class LocationManager
        : AggregateManager<LocationAggregate, LocationId, Command<LocationAggregate, LocationId>>
    {
        public LocationManager()
        {
        }
    }
}