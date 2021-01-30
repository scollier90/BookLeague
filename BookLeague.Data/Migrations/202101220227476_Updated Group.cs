namespace BookLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedGroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Group", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Group", new[] { "Id" });
            AlterColumn("dbo.Group", "Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Group", "Id");
            AddForeignKey("dbo.Group", "Id", "dbo.ApplicationUser", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Group", "Id", "dbo.ApplicationUser");
            DropIndex("dbo.Group", new[] { "Id" });
            AlterColumn("dbo.Group", "Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Group", "Id");
            AddForeignKey("dbo.Group", "Id", "dbo.ApplicationUser", "Id", cascadeDelete: true);
        }
    }
}
