using api_rest_logistics.Models;
using api_rest_logistics.Security;
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web.Http;

namespace api_rest_logistics.Controllers
{
    
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
       
        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            try
            {
                using (Model db = new Model())
                {
                    var password = login.Password;
                   
                    string encryptPassword = EncryptGenerator.Encrypt(password);
                                       
                    var lst = db.Usuario
                        .Where(d => d.Username == login.Username && d.Pass == encryptPassword && d.Active == true);


                    if (lst.Count() > 0)
                    {

                        var rolename = "Developer";
                        var token = TokenGenerator.GenerateTokenJwt(login.Username, rolename);
                        return Ok(token);

                    }
                    else
                    {
                        return Unauthorized();
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

      
    }

}