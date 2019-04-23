using Akkatecture.Aggregates;

namespace Points {
    public class Point
        : AggregateRoot<Point, PointId, PointState> {
            public Point (PointId id) : base (id) { }
        }
}