using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AngularJSAuthentication;
using AngularJSAuthentication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngularJSAuthentication
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<IdentityUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterUser(ApplicationUser userModel)
        {
            var user = new ApplicationUser()
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Password = userModel.Password,
                ConfirmPassword = userModel.ConfirmPassword,
                Email = userModel.Email,
            };

            //Player player = new Player
            //{
            //    UserName = userModel.UserName,
            //    FirstName = userModel.FirstName,
            //    LastName = userModel.FirstName,
            //    AspUserId = user.Id
            //};
            
            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        //public void RegisterPlayer(Player userModel, IdentityResult user)
        //{
        //    Player player = new Player
        //    {
        //        UserName = userModel.UserName,
        //        FirstName = userModel.FirstName

        //    };

        //    //var result = await _userManager.CreateAsync(user, userModel.Password);

        //    //return result;
        //}

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }


        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}