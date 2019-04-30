using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Akkatecture.Akka;
using Gateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers {
    [Route ("actor/[controller]")]
    public class HomeController : Controller {
        public ActorRefProvider<GatewayActor> _gatewayGateway { get; private set; }
        public HomeController (ActorRefProvider<GatewayActor> apiGateway) {
            _gatewayGateway = apiGateway;
        }

        [HttpGet ("Index")]
        public IActionResult Index () {

            var membership = new ServiceIndex ();
            membership.Title = "Membership";
            membership.Actions = new List<ServiceAction> ();
            var register = new ServiceAction () {
                Id = "AA3CA589-DB54-476C-8EBA-2253776D7E57",
                Title = "Register",
                Url = "#Register"
            };
            var setCredential = new ServiceAction () {
                Id = "AA3CA589-DB54-476C-8EBA-2253776D7E54",
                Title = "setCredential",
                Url = "#setCredential"
            };

            membership.Actions.Add (register);
            membership.Actions.Add (setCredential);

            var sevicesIndex = new List<ServiceIndex> ();
            sevicesIndex.Add (membership);

            return View (sevicesIndex);
            //return Ok ("Gateway is Running)");
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}