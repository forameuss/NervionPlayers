using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace nervionPlayers_API.Controllers
{
    [Route("api/Token")]
    public class TokenController : Controller
    {
        // GET: /<controller>/
        public void Index()
        {
            String auth = Request.Headers["Authorization"];
            auth = Encoding.UTF8.GetString(Convert.FromBase64String(auth));
            String[] miPersona = auth.Split(':');
            
        }
    }
}
