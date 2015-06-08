namespace ResQ.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cmd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FireStations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FireStationName = c.String(),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.LocationId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        House_Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        LocationId = c.Int(nullable: false),
                        FireStationId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.FireStations", t => t.FireStationId, cascadeDelete: true)
                .ForeignKey("dbo.Locations", t => t.LocationId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.LocationId)
                .Index(t => t.FireStationId);
            
            AddColumn("dbo.AspNetUsers", "UserLastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Requests", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Requests", "LocationId", "dbo.Locations");
            DropForeignKey("dbo.Requests", "FireStationId", "dbo.FireStations");
            DropForeignKey("dbo.FireStations", "LocationId", "dbo.Locations");
            DropIndex("dbo.Requests", new[] { "FireStationId" });
            DropIndex("dbo.Requests", new[] { "LocationId" });
            DropIndex("dbo.Requests", new[] { "UserId" });
            DropIndex("dbo.FireStations", new[] { "LocationId" });
            DropColumn("dbo.AspNetUsers", "UserLastName");
            DropTable("dbo.Requests");
            DropTable("dbo.Locations");
            DropTable("dbo.FireStations");
        }
    }
}
