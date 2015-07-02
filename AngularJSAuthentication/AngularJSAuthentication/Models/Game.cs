using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSAuthentication.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public List<Tournament> Tournaments { get; set; }
    }
}