// using Akkatecture.Aggregates;
// using Akkatecture.Events;

// namespace Gateway.Events {
//     [EventVersion ("MemberVerificationResponse", 1)]
//     public class MemberVerificationResponse : AggregateEvent<MemberAggregate, MemberId> {
//         public MemberVerificationResponse (bool isSucceed, MemberId memberId) {
//             this.IsSucceed = isSucceed;
//             this.MemberId = memberId;

//         }
//         public bool IsSucceed { get; set; }
//         public MemberId MemberId { get; set; }
//     }
// }