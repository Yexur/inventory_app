namespace GameTrackerAngV1.Persistance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Double(nullable: false),
                        Publisher = c.String(),
                        Designer = c.String(),
                        NumberOfPlayers = c.String(),
                        PlayingTime = c.String(),
                        PurchaseMonth = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Note = c.String(),
                        Status_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.ItemStatus", t => t.Status_Id, cascadeDelete: true)
                .Index(t => t.Status_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryType = c.String(nullable: false),
                        CategoryGroup_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CategoryGroups", t => t.CategoryGroup_Id, cascadeDelete: true)
                .Index(t => t.CategoryGroup_Id);
            
            CreateTable(
                "dbo.CategoryGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryGroupType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VideoGames",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Double(nullable: false),
                        Publisher = c.String(),
                        Developer = c.String(),
                        ReleaseDate = c.String(),
                        PurchaseMonth = c.String(),
                        Description = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        Note = c.String(),
                        Genre_Id = c.Int(nullable: false),
                        Status_Id = c.Int(nullable: false),
                        Tracking_Id = c.Int(nullable: false),
                        Category_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id, cascadeDelete: true)
                .ForeignKey("dbo.Genres", t => t.Genre_Id, cascadeDelete: true)
                .ForeignKey("dbo.ItemStatus", t => t.Status_Id, cascadeDelete: true)
                .ForeignKey("dbo.TrackingCodes", t => t.Tracking_Id, cascadeDelete: true)
                .Index(t => t.Genre_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Tracking_Id)
                .Index(t => t.Category_Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GenreType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TrackingCodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TrackingCodeType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VideoGames", "Tracking_Id", "dbo.TrackingCodes");
            DropForeignKey("dbo.VideoGames", "Status_Id", "dbo.ItemStatus");
            DropForeignKey("dbo.BoardGames", "Status_Id", "dbo.ItemStatus");
            DropForeignKey("dbo.VideoGames", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.VideoGames", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Categories", "CategoryGroup_Id", "dbo.CategoryGroups");
            DropForeignKey("dbo.BoardGames", "Category_Id", "dbo.Categories");
            DropIndex("dbo.VideoGames", new[] { "Category_Id" });
            DropIndex("dbo.VideoGames", new[] { "Tracking_Id" });
            DropIndex("dbo.VideoGames", new[] { "Status_Id" });
            DropIndex("dbo.VideoGames", new[] { "Genre_Id" });
            DropIndex("dbo.Categories", new[] { "CategoryGroup_Id" });
            DropIndex("dbo.BoardGames", new[] { "Category_Id" });
            DropIndex("dbo.BoardGames", new[] { "Status_Id" });
            DropTable("dbo.TrackingCodes");
            DropTable("dbo.ItemStatus");
            DropTable("dbo.Genres");
            DropTable("dbo.VideoGames");
            DropTable("dbo.CategoryGroups");
            DropTable("dbo.Categories");
            DropTable("dbo.BoardGames");
        }
    }
}
