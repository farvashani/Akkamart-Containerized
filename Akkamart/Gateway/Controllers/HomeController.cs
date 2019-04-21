using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Akka.Actor;
using Gateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers {
    [Route ("[controller]")]
    public class HomeController : Controller {
        public IActorRef _gatewayGateway { get; private set; }
        public HomeController (IActorRef apiGateway) {
            _gatewayGateway = apiGateway;
        }

        [HttpGet ("Index")]
        public IActionResult Index () {
            return Ok ("Gateway is Running)");
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