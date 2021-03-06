﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AngularJSAuthentication.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AngularJSAuthentication
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {

        //public string FirstName { get; set; }
        //public string LastName { get; set; }
       

        public AuthContext()
            : base("AuthContext")
        {

        }

        public System.Data.Entity.DbSet<ApplicationUser> Players { get; set; }

        public System.Data.Entity.DbSet<Tournament> Tournaments { get; set; }

        public System.Data.Entity.DbSet<Game> Games { get; set; }


        //protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);


        //    modelBuilder.Entity<Player>().ToTable("Players", "dbo");
        //    modelBuilder.Entity<IdentityUser>().ToTable("Players", "dbo");

        //}

    }

}