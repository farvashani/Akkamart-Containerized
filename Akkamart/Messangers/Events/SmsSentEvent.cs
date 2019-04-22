using System;
using Akkatecture.Aggregates;
using Akkatecture.Events;

namespace Messangers {

    [EventVersion ("SmsSentEvent", 1)]
    public class SmsSentEvent : AggregateEvent<SmsAggregate, SmsId> {

        public SmsSentEvent (string recipient, string messageBody, DateTime sendingDate) {
            this.Recipient = new Recipient (recipient);
            this.MessageBody = new MessageBody (messageBody);
            this.SendingDate = new SendingDate (sendingDate);

        }
        public Recipient Recipient { get; private set; }
        public MessageBody MessageBody { get; private set; }
        public SendingDate SendingDate { get; set; }
    }

}