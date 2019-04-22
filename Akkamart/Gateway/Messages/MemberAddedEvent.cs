namespace Gateway {
    public class MemberAddedEvent {
        public string MemberId { get; set; }
        public bool IsSucceed { get; internal set; }

    }
}