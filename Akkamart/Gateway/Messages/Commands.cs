namespace Gateway {

    public class Register {

        public Register (string mobilenumber) {
            this.Mobilenumber = mobilenumber;

        }
        public string Mobilenumber { get; private set; }
    }
    public class Login {
        public Login (string username, string password) {
            this.Username = username;
            this.Password = password;

        }

        public string Username { get; private set; }
        public string Password { get; private set; }

    }
    public class VerifyMemberCommand {
        private object memberId;
        private string verificationCode;

        public VerifyMemberCommand (object memberId, string verificationCode) {
            this.memberId = memberId;
            this.verificationCode = verificationCode;
        }
    }
   
  

    public class AddCredentialForMember {
        public AddCredentialForMember (string memberId, string username, string password) {
            this.MemberId = memberId;
            this.Username = username;
            this.Password = password;

        }
        public string MemberId { get; private set; }

        public string Username { get; private set; }
        public string Password { get; private set; }

    }

    public class AddMember {
        public AddMember (string mobilenumber) {
            this.Mobilenumber = mobilenumber;

        }
        public string Mobilenumber { get; set; }

    }

    public class VerifyMobileNumber {
        public VerifyMobileNumber (string enteredVerificationCode, string memberId) {
            this.EnteredVerificationCode = enteredVerificationCode;
            this.MemberId = memberId;

        }
        public string EnteredVerificationCode { get; private set; }
        public string MemberId { get; private set; }

    }
    public class GenerateVerificationCode {

    }
    public class SendNewVerificationCode {
        public string MemberId { get; private set; }
        public SendNewVerificationCode (string memberId) {
            MemberId = memberId;

        }

    }
    public class GetMemberState {
        public GetMemberState (string memberId) {
            this.MemberId = memberId;

        }
        public string MemberId { get; set; }

    }
    public class MemberStateResponse {

    }
}