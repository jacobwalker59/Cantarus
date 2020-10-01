using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SupermarketInterfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingController : ControllerBase
    {
        private readonly IPricings _pricings;
        public PricingController(IPricings pricings)
        {
            _pricings = pricings;

        }

         // insert methods for controllers, would use [fromBody] to get the JSON query from postman]

    }
}
