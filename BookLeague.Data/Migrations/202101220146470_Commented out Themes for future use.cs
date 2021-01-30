namespace BookLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentedoutThemesforfutureuse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Theme", "Book_BookId", "dbo.Book");
            DropIndex("dbo.Theme", new[] { "Book_BookId" });
            DropColumn("dbo.Theme", "Book_BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Theme", "Book_BookId", c => c.Int());
            CreateIndex("dbo.Theme", "Book_BookId");
            AddForeignKey("dbo.Theme", "Book_BookId", "dbo.Book", "BookId");
        }
    }
}
