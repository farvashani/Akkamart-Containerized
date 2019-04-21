using System;
using Akka.Actor;
using Akkatecture.Aggregates;
using Credentialss;

namespace Credentials {
    public class CredentialRoot : AggregateRoot<CredentialRoot, CredentialId, CredentialState> {
        public CredentialRoot (CredentialId id) : base (id) {
            Command<StoreCredential> (Execute);
            Command<ValidateCredentialCommand> (Execute);
            // Command<SuccessfullLoginResponse> (Execute);
            // Command<UnSuccessfullLoginResponse> (Execute);

        }

        private bool Execute (StoreCredential cmd) {
            if (!string.IsNullOrEmpty (cmd.Username.Value) &&
                !string.IsNullOrEmpty (cmd.Password.Value)) {
                var @event = new CredentialStoredEvent (cmd.MemberId, cmd.CredentialId);
                Emit (@event);
                return true;
            }
            return false;

        }
        private bool Execute (UnSuccessfullLoginResponse obj) {
            throw new NotImplementedException ();
        }

        private bool Execute (SuccessfullLoginResponse obj) {
            throw new NotImplementedException ();
        }

        private bool Execute (ValidateCredentialCommand cmd) {
            // var credentialId = CredentialId.NewDeterministic(CredentialNamespace.Instance, $"{cmd.Username}{cmd.Password}");
            if (!string.IsNullOrEmpty (cmd.Username) &&
                !string.IsNullOrEmpty (cmd.Password) &&
                this.State.CredentialId == Id && this.State.MemberId != null) {
                var @event = new LoginResultResponse (true, this.State.MemberId);
                Sender.Tell (@event);
                return true;
            } else {
                var @event = new LoginResultResponse (false, null);
                Sender.Tell (@event);
                return false;
            }

        }
    }
}