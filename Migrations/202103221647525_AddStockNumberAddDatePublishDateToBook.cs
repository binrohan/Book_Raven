namespace Book_Raven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockNumberAddDatePublishDateToBook : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "PublisheDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "AddDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Books", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "NumberInStock");
            DropColumn("dbo.Books", "AddDate");
            DropColumn("dbo.Books", "PublisheDate");
        }
    }
}
