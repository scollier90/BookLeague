namespace BookLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentedoutApplicationUserfromgroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUser", "Group_GroupId", "dbo.Group");
            DropIndex("dbo.ApplicationUser", new[] { "Group_GroupId" });
            DropColumn("dbo.ApplicationUser", "Group_GroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ApplicationUser", "Group_GroupId", c => c.Int());
            CreateIndex("dbo.ApplicationUser", "Group_GroupId");
            AddForeignKey("dbo.ApplicationUser", "Group_GroupId", "dbo.Group", "GroupId");
        }
    }
}
