namespace BookLeague.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatedentities : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "CreatorId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "CreatorId");
        }
    }
}
