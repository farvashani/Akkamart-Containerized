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
            return View (sevicesIndex);
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