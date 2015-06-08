namespace ResQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class secondMigr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "DateFinished", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "DateFinished");
        }
    }
}
