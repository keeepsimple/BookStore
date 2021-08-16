namespace BookStore.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailToReviewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("common.Reviews", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("common.Reviews", "Email");
        }
    }
}
