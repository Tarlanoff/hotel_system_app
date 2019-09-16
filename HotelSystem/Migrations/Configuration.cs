namespace HotelSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HotelSystem.Models;
    using HotelSystem.Data;
    using System.Web.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelSystem.Data.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelSystem.Data.HotelContext context)
        {
            Group grp = new Group
            {
                Name = "Admin"
            };
            context.Groups.Add(grp);
            context.SaveChanges();

            string password = "1234";
            User user = new User
            {
                FullName = "Tamerlan Terlanoff",
                Email = "tamerlan@com.az",
                Password= Crypto.HashPassword(password),
                GroupId=2

            };
            context.Users.Add(user);
            context.SaveChanges();

            
        }
    }
}
