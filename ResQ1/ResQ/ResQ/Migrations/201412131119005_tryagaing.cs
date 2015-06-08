namespace ResQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tryagaing : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "UserFirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "UserFirstName");
        }
    }
}
