using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaltaStore.Api.Controllers
{
    public class HomeController : Controller
    {

        [Route("")]
        public string Get()
        {
            return "Hellor Word";
        }
    }
}
