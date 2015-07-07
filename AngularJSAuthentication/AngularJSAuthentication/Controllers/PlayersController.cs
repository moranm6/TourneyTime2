using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngularJSAuthentication.Controllers
{
    [RoutePrefix("api/Orders")]
    public class PlayersController : ApiController
    {
        private AuthContext _authContext;

        [Authorize]
        [Route("{username}")]
        public IHttpActionResult Get(string username)
        {
            //return Ok(_authContext.Users.ToList());
            return Ok(Player.GetLoggedInUser(username));
        }

    }

    #region Helpers

    public class Player
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipperCity { get; set; }
        public Boolean IsShipped { get; set; }

        public static ApplicationUser GetLoggedInUser(string username)
        {


            AuthContext _authContext = new AuthContext();

            var authContext = _authContext;

            //var playList = _authContext.Users.ToList(); 

            ApplicationUser NoUser = new ApplicationUser()
            {
                FirstName = "No User Logged In",
                LastName = "",
                UserName = "NoUser"

            };

            var user = (from p in authContext.Players
                where p.UserName == username
                select p).SingleOrDefault() ?? NoUser;

            var loggedInUser = new ApplicationUser();
            loggedInUser.FirstName = user.FirstName;
            loggedInUser.LastName = user.LastName;
            loggedInUser.ConfirmPassword = user.ConfirmPassword;
            loggedInUser.Password = user.Password;
            loggedInUser.Games = user.Games;
            loggedInUser.Tournaments = user.Tournaments;
            loggedInUser.UserName = user.UserName;

            return loggedInUser;
        }
    }

    #endregion
}
