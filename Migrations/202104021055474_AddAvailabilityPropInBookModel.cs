namespace Book_Raven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailabilityPropInBookModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Availability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Availability");
        }
    }
}
