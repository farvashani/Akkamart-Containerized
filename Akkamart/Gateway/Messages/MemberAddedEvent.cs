namespace Gateway {
    public class MemberAddedEvent {

        public MemberAddedEvent (string memberId, bool isSucceed) {
            this.MemberId = memberId;
            this.IsSucceed = isSucceed;

        }
        public string MemberId { get; private set; }
        public bool IsSucceed { get; private set; }

    }
}