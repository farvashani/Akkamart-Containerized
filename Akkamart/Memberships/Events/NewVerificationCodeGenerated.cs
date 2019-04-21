using Akkatecture.Aggregates;
using Akkatecture.Commands;
using Memberships;

namespace Memberships {
    public class NewVerificationCodeGeneratedEvent : AggregateEvent<MemberAggregate, MemberId> {
        public NewVerificationCodeGeneratedEvent (VerificationCode verificationCode) {
            this.VerificationCode = verificationCode;

        }
        public NewVerificationCodeGeneratedEvent (VerificationCode verificationCode, MobileNumber mobileNumber) {
            this.VerificationCode = verificationCode;
            this.MobileNumber = mobileNumber;

        }
        public VerificationCode VerificationCode { get; set; }
        public MobileNumber MobileNumber { get; set; }

    }
}