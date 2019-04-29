using System;
using Akka.Actor;
using Akka.Event;
using Akkatecture.Aggregates;
using Akkatecture.Specifications.Provided;
using Memberships;

namespace Memberships
{
    public class MemberAggregate : AggregateRoot<MemberAggregate, MemberId, MemberState>
    {

        private readonly ILoggingAdapter _logger = Context.GetLogger();
        public IActorRef _CredentialActorRef { get; private set; }
        public MemberAggregate(MemberId id) : base(id)
        {
            Command<CreateMemberCommand>(Execute);
            Command<GetMemberbyIdCommand>(Execute);
            //Command<RequestNewCredential> (Execute);
            Command<RequestNewVerificationCode>(Execute);
            Command<RequestNewVerificationCode>(Execute);
            Command<VerifyMemberCommand>(Execute);
            Command<RequestMemberAddCredentialCommand>(Execute);
        }
        private bool Execute(CreateMemberCommand command)
        {
            //this spec is part of Akkatecture
            var spec = new AggregateIsNewSpecification();
            if (spec.IsSatisfiedBy(this))
            {
                var aggregateEvent =
                    new MemberCreatedEvent(new MobileNumber(command.Mobilenumber), this.Id);
                Emit(aggregateEvent);
                Sender.Tell(aggregateEvent);
                return true;
            }

            return false;
        }
        private bool Execute(GetMemberbyIdCommand cmd)
        {
            var response = new MemberStateResponse(this.State);
            Sender.Tell(response);
            return true;
        }

        // private bool Execute (RequestNewCredential cmd) {
        //     if (!this.IsNew) {
        //         var credentialId = CredentialId.NewDeterministic (CredentialNamespace.Instance, $"{cmd.Username}{cmd.Password}");

        //         var credentialManager = Context.ActorOf (Props.Create<CredentialManager> ());
        //         credentialManager.Tell (new StoreCredential (credentialId, cmd.Username,
        //             cmd.Password,
        //             cmd.MemberId));

        //         Emit (new CredentialRequested (cmd.MemberId, credentialId));
        //         return true;

        //     } else
        //         return false;

        // }
        private bool Execute(RequestNewVerificationCode command)
        {
            VerificationCode verificationcode = new VerificationCode((GenerateRandomNo().ToString()));

            var aggregateEvent =
                new VerificationCodeRequestedEvent(verificationcode, this.State.Mobilenumber);
            Emit(aggregateEvent);

            return true;
        }
        private bool Execute(VerifyMemberCommand cmd)
        {
            if (this.State.VerificationCode.Value == cmd.Code)
            {
                var @event = new MemberVerifiedEvent(true, Id);
                Emit(@event);
                Sender.Tell(new MemberVerificationResponse(true, Id));
                return true;
            }
            else
            {
                Sender.Tell(new MemberVerificationResponse(false, Id));
                return false;
            }

        }
        private bool Execute(RequestMemberAddCredentialCommand cmd)
        {
            var @event =
                new MemberAddCredentialEvent(this.Id,new Username(cmd.Username),new Password(cmd.Password));
            Emit(@event);

            return true;
        }








        private int GenerateRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }
    }
}