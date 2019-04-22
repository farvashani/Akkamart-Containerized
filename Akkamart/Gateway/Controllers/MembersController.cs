using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Akkatecture.Akka;
using Gateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers {
    [Route ("[controller]")]
    //[ApiController]
    public class MembersController : Controller {
        private readonly ActorRefProvider<GatewayActor> _gateway;
        public MembersController (ActorRefProvider<GatewayActor> gateway) {
            _gateway = gateway;
        }

        [HttpGet (nameof (Index))]
        public ActionResult<string> Index () {
            return Ok ("Memberhsip service is up");

        }

        [HttpGet ("members/{id}")]
        public async Task<ActionResult<string>>  Get (string id) {

            var member = await _gateway.Ask<MemberStateResponse> (new GetMemberState (id));
            return Ok (member);
            // return Ok ();
        }

        // POST
        [HttpPost ("Register")]
        public async Task<IActionResult> Register ([FromBody] AddMemberDto model) {

            var cmd = new AddMember (model.Mobilenumber);
            // // _gateway.Tell(cmd);
            var member = await _gateway.Ask<AddMemberResponse> (cmd);

            return Ok (member);

            // return Ok ();
            //return Accepted();
        }

        [HttpPost ("VerifyMember")]
        public async Task<IActionResult> VerifyMember (VerifyMemberDTO model) {

            var cmd = new VerifyMemberCommand (model.MemberId, model.VerificationCode);
            var result = await _gateway.Ask<MemberVerificationResponse> (cmd);
            if (result.IsSucceed)
                return Ok (model.MemberId);
            else
                return BadRequest (result);
            // return Ok ();
        }

        [HttpPost ("Login")]
        public async Task<IActionResult> Login (LoginDto model) {
            var cmd = new Login (model.Username, model.Password);
            var result = await _gateway.Ask (cmd);

            return Ok (result);
            // return Ok ();
        }

        [HttpPost ("SetCredential/{id}")]
        public IActionResult SetCredential (string id, LoginDto model) {
            if (id.StartsWith ("member-"))
                id = id.Remove (id.IndexOf ("member-"), "member-".Length);

            var cmd = new AddCredentialForMember (id, model.Username, model.Password);
            _gateway.Tell (cmd);

            return Accepted ();
            // return Ok ();
        }
    }
}