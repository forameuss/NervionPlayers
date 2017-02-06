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
            //Recuperamos la cabecera sin Basic
            String auth = Request.Headers["Authorization"];
            auth=auth.Substring(6);

            //Decodificamos de base64 a texto plano
            auth = Encoding.UTF8.GetString(Convert.FromBase64String(auth));
            String[] miPersona = auth.Split(':');

//            //Web ejemplos
//            Explicación por partes
//Parte 1:
        //https://goblincoding.com/2016/07/03/issuing-and-authenticating-jwt-tokens-in-asp-net-core-webapi-part-i/
//            Parte 2:
//https://goblincoding.com/2016/07/07/issuing-and-authenticating-jwt-tokens-in-asp-net-core-webapi-part-ii/

        }
    }
}
