using System;
using Akka.Actor;
using Akkatecture.Aggregates;

namespace Messangers {
    public class SmsAggregate : AggregateRoot<SmsAggregate, SmsId, SmsState> {
        public SmsService SmsService { get; set; }

        public SmsAggregate (SmsId id) : base (id) {
            //this.SmsService = smsService;
            if (SmsService == null) {
                var apiKey = "532B6666684D51474166335A5548626F6C686430553264516935733037365745";
                SmsService = new SmsService (apiKey);
            }

            Command<SendSmsCommand> (Execute);
            Command<SmsSentResult> (Execute);

        }

        private bool Execute (SmsSentResult cmd) {
            if (cmd.IsSucceed) {
                Emit (new SmsSentEvent (cmd.Recipient, cmd.MessageBody, cmd.SendnigDate));
                return true;
            } else {
                return false;
            }
        }

        private bool Execute (SendSmsCommand cmd) {
            RequestModel sendParameters = new RequestModel () {
                receptor = new string[] { cmd.Recipient },
                sender = new string[] { "10004346" },
                message = new string[] { cmd.MessageBody }
            };
            SmsService.Send (sendParameters).ContinueWith (r => {
                var smsSentEvent = new SmsSentResult (this.Id, cmd.Recipient,
                    cmd.MessageBody, DateTime.UtcNow);
            }).PipeTo (Self);

            return true;
        }
    }
}