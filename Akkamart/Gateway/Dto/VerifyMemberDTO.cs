namespace Gateway.Models {
    public class VerifyMemberDTO {
        private string memberId;

        public string MemberId {
            get {
                if (memberId.StartsWith ("member-"))
                    memberId = memberId.Remove (memberId.IndexOf ("member-"), "member-".Length);
                return memberId;
            }

            set {
                if (value.StartsWith ("member-"))
                    value = memberId.Remove (value.IndexOf ("member-"), "member-".Length);
                memberId = value;
            }
        }
        public string VerificationCode { get; set; }
    }
}