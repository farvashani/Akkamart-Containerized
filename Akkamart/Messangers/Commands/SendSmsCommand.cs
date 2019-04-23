using System;
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
    public class SmsSentResult : Command<SmsAggregate, SmsId> {
        public bool IsSucceed { get; private set; }
        public string Recipient { get; private set; }
        public string MessageBody { get; private set; }
        public DateTime SendnigDate { get; private set; }

        public SmsSentResult (SmsId aggregateId, string recipient, string messageBody, DateTime sendnigDate, bool isSucceed = true) : base (aggregateId) {

            this.Recipient = recipient;
            this.MessageBody = messageBody;
            this.SendnigDate = sendnigDate;
        }
    }

}