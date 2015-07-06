using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngularJSAuthentication.Controllers
{
    [RoutePrefix("api/Orders/{username}")]
    public class PlayersController : ApiController
    {
        private AuthContext _authContext;

        [Authorize]
        [Route("")]
        public IHttpActionResult Get(string username)
        {
            //return Ok(_authContext.Users.ToList());
            return Ok(Player.CreatePlayers(username));
        }

    }

    #region Helpers

    public class Player
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipperCity { get; set; }
        public Boolean IsShipped { get; set; }

        public static List<String> CreatePlayers(string username)
        {


            AuthContext _authContext = new AuthContext();

            var authContext = _authContext;

            //var playList = _authContext.Users.ToList(); 

            var playList = (from p in authContext.Players
                         where p.UserName == username
                         orderby p.FirstName
                         select p.FirstName).ToList();

            return playList;
        }
    }

    #endregion
}
