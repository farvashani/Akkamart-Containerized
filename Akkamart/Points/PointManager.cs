using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Points {
    public class PointManager
        : AggregateManager<Point, PointId, Command<Point, PointId>> {

        }
}