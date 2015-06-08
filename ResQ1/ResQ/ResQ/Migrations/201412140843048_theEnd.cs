namespace ResQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class theEnd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HelpInfoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.HelpInfoes");
        }
    }
}
