using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public List<Game> Games { get; set; }

    }
}