namespace Book_Raven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockNumberAddDatePublishDateToBook1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AddedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "AddDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "AddDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "AddedDate");
        }
    }
}
