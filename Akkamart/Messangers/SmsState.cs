using Akkatecture.Aggregates;

namespace Messangers {
    public class SmsState : AggregateState<SmsAggregate, SmsId>
        //IApply<MemberCreatedEvent>,
        {
            public MessageBody Message { get; private set; }
            public Recipient Recipient { get; private set; }
            public SendingDate SendingDate { get; private set; }

        }
}