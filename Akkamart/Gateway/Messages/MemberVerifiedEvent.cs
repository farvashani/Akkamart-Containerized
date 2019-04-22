namespace Gateway {
    public class MemberVerifiedEvent {
        public bool IsSucceed { get; internal set; }
        public string MemberId { get; set; }
    }
}