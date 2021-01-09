namespace BookLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedThemeclass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        BookName = c.String(nullable: false),
                        Description = c.String(),
                        Genre = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PageCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Theme",
                c => new
                    {
                        ThemeId = c.Int(nullable: false, identity: true),
                        ThemeName = c.String(nullable: false),
                        Book_BookId = c.Int(),
                    })
                .PrimaryKey(t => t.ThemeId)
                .ForeignKey("dbo.Book", t => t.Book_BookId)
                .Index(t => t.Book_BookId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventName = c.String(nullable: false),
                        GroupId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        ScheduledDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Book", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Group", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.BookId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Event", "GroupId", "dbo.Group");
            DropForeignKey("dbo.Event", "BookId", "dbo.Book");
            DropForeignKey("dbo.Theme", "Book_BookId", "dbo.Book");
            DropIndex("dbo.Event", new[] { "BookId" });
            DropIndex("dbo.Event", new[] { "GroupId" });
            DropIndex("dbo.Theme", new[] { "Book_BookId" });
            DropTable("dbo.Event");
            DropTable("dbo.Theme");
            DropTable("dbo.Book");
        }
    }
}
