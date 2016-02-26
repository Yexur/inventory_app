namespace GameTrackerAngV1.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BoardGames", "Status", c => c.String(nullable: false));
            AddColumn("dbo.VideoGames", "Status", c => c.String(nullable: false));
            DropColumn("dbo.BoardGames", "HobbyStatus");
            DropColumn("dbo.VideoGames", "HobbyStatus");
            DropTable("dbo.HobbyItemStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.HobbyItemStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ItemStatus = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VideoGames", "HobbyStatus", c => c.String(nullable: false));
            AddColumn("dbo.BoardGames", "HobbyStatus", c => c.String(nullable: false));
            DropColumn("dbo.VideoGames", "Status");
            DropColumn("dbo.BoardGames", "Status");
            DropTable("dbo.ItemStatus");
        }
    }
}
