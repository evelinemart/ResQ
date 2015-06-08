namespace ResQ.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ResQ.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ResQ.Models.ApplicationDbContext";
        }

        protected override void Seed(ResQ.Models.ApplicationDbContext context)
        {
           
        }
    }
}
