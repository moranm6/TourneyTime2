using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AngularJSAuthentication.Models;
using Microsoft.AspNet.Identity;

namespace AngularJSAuthentication.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;
        private AuthContext db;

        public AccountController()
        {
            _repo = new AuthRepository();
            db = new AuthContext();
        }

        // POST api/Account/AddGame
        [AllowAnonymous]
        [Route("AddGame")]
        public void AddGame(Game game)
        {
            //var user = db.Players.Find(playerId);
            //db.Games.Add(game);
            //db.SaveChanges();

            //var userToAdd = db.Players.Find("11dd5c6b-629c-4b79-9aae-de6eefad226c");
            var userToAdd = (from users in db.Players
                where users.UserName.Equals("jbauer777")
                select users).FirstOrDefault();
            var gameCheck = db.Games.Find(1);
            //gameCheck.ApplicationUsers.Add(userToAdd);
            userToAdd.Games.Add(gameCheck);
            db.SaveChanges();
        }


        // POST api/Account/AddGameToPlayer
        [AllowAnonymous]
        [Route("AddGameToPlayer")]
        public void AddGameToPlayer(Game game, string playerId)
        {
            var userToAdd = db.Players.Find(playerId);
            var gameCheck = db.Games.Find(game.Id);
            gameCheck.ApplicationUsers.Add(userToAdd);
            db.SaveChanges();
        }

        // POST api/Account/Register
        [AllowAnonymous]
        [Route("Register")]
        public async Task<IHttpActionResult> Register(ApplicationUser userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityResult result = await _repo.RegisterUser(userModel);
            
            IHttpActionResult errorResult = GetErrorResult(result);

            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}
