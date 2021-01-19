namespace BookLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedcreatorIdtoEventandGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Event", "CreatorId", c => c.Guid(nullable: false));
            AddColumn("dbo.Group", "CreatorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Group", "CreatorId");
            DropColumn("dbo.Event", "CreatorId");
        }
    }
}
