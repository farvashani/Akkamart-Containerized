using System.Reflection;
using Akkatecture.Commands;

namespace Memberships {
    public class RequestMemberAddCredentialCommand : Command<MemberAggregate, MemberId> {
        public RequestMemberAddCredentialCommand (MemberId aggregateId, string username, string password) : base (aggregateId) {
            Username = username;
            Password = password;
        }
        public string Username { get; private set; }
        public string Password { get; private set; }
    }
}