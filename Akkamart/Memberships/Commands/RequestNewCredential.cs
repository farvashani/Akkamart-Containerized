using System;
using Akkatecture.Commands;
using Memberships;

namespace Memberships {
    public class RequestNewCredential : Command<MemberAggregate, MemberId> {
        public RequestNewCredential (MemberId aggregateId) : base (aggregateId) { }

        public RequestNewCredential (MemberId aggregateId, Username username, Password password, MemberId memberId) : base (aggregateId) {
            this.Username = username;
            this.Password = password;
            this.MemberId = memberId;

        }

        public Username Username { get; private set; }
        public Password Password { get; private set; }
        public MemberId MemberId { get; private set; }

    }
}