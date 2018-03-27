using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace PetHospital.Areas.API.Controllers
{
    public class TestController : ApiController
    {
        [HttpPost]
        public LappResponse<User> F5(User user)
        {
            var rm = new LappResponse<User>() { Data = user };

            return rm;
        }

    }
}