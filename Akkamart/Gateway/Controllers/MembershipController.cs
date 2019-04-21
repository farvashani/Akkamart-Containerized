using System;
using System.Threading.Tasks;
using Akka.Actor;
using Akkatecture.Akka;
using Gateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers {
    [Route ("api/[controller]")]
    [ApiController]

    public class MembershipController : Controller {
        // private readonly ActorRefProvider<APIActor> _API;
        //   //  public MembershipController (ActorRefProvider<APIActor> api) {
        //       _API = api;
        //   //  }

        public MembershipController () {

        }

        [HttpGet (nameof (Index))]
        public ActionResult<string> Index () {
            return Ok ("Memberhsip service is up");

        }

        [HttpGet ("members/{id}")]
        public ActionResult<string> Get (string id) {
            // if (id.StartsWith ("member-"))
            //     id = id.Remove (id.IndexOf ("member-"), "member-".Length);

            // var memberid = MemberId.With (Guid.Parse (id));
            // var member = await _API.Ask<MemberStateResponse> (new GetMemberbyIdCommand (memberid));
            // return Ok (member);
            return Ok ();
        }

        // POST
        [HttpPost ("Register")]
        public IActionResult Register ([FromBody] AddMemberDto model) {
            // ColorConsole.WriteMagenta ("AddMember from MembershipController Started");
            // var id = MemberId.New;
            // var cmd = new CreateMemberCommand (id, model.Mobilenumber);
            // // _API.Tell(cmd);
            // var member = await _API.Ask<MemberCreatedEvent> (new CreateMemberCommand (id, model.Mobilenumber));

            // return Ok (member);

            // //return Accepted();
            return Ok ();
        }

        [HttpPost ("VerifyMember")]
        public IActionResult VerifyMember (VerifyMemberDTO model) {
            // var memberId = MemberId.With (Guid.Parse (model.MemberId));
            // var cmd = new VerifyMemberCommand (memberId, model.VerificationCode);
            // var result = await _API.Ask<MemberVerificationResponse> (cmd);
            // if (result.IsSucceed)
            //     return Ok (memberId);
            // else
            //     return BadRequest (result);
            return Ok ();
        }

        [HttpPost ("Login")]
        public IActionResult Login (LoginDto model) {
            // var cmd = new Login (model.Username, model.Password);
            // var result = await _API.Ask (cmd);

            // return Ok (result);
            return Ok ();
        }

        [HttpPost ("SetCredential/{id}")]
        public IActionResult SetCredential (string id, LoginDto model) {
            // if (id.StartsWith ("member-"))
            //     id = id.Remove (id.IndexOf ("member-"), "member-".Length);

            // var cmd = new AddCredentialForMember (id, model.Username, model.Password);
            // _API.Tell (cmd);

            // return Accepted ();
            return Ok ();
        }

        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }

        // //DELETE api/values/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}