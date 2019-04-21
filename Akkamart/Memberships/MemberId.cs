using Akkatecture.Core;
using Newtonsoft.Json;
namespace Memberships {
    public class MemberId : Identity<MemberId> {
        public MemberId (string value) : base (value) { }
    }
}