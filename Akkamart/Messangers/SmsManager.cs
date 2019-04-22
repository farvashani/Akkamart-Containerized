using Akkatecture.Aggregates;
using Akkatecture.Commands;

namespace Messangers {
    public class SmsManager : AggregateManager<SmsAggregate, SmsId, Command<SmsAggregate, SmsId>> {

    }
}