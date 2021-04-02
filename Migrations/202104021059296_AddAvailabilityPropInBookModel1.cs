namespace Book_Raven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailabilityPropInBookModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "NumberAvailable", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "Availability");

            Sql("UPDATE Books SET NumberAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Availability", c => c.Int(nullable: false));
            DropColumn("dbo.Books", "NumberAvailable");
        }
    }
}
