using Akkatecture.Commands;

namespace Messangers {

    public class SendSmsCommand : Command<SmsAggregate, SmsId> {

        public SendSmsCommand (SmsId aggregateId,
            string recipient,
            string message) : base (aggregateId) {
            this.Recipient = recipient;
            this.MessageBody = message;

        }

        public string Recipient { get; set; }
        public string MessageBody { get; set; }

    }

}