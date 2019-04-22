using System;
using Akkatecture.Aggregates;

namespace Messangers {
    public class SmsAggregate : AggregateRoot<SmsAggregate, SmsId, SmsState> {

        public SmsAggregate (SmsId id) : base (id) {
            Command<SendSmsCommand> (Execute);

        }

        private bool Execute (SendSmsCommand cmd) {
            var smsSentEvent = new SmsSentEvent (cmd.Recipient, cmd.MessageBody, DateTime.UtcNow);
            Emit (smsSentEvent);
            return true;
        }
    }
}