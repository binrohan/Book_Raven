namespace Book_Raven.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenre : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) VALUES(1, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(2, 'Drama')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(3, 'Novel')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(4, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES(5, 'Comedy')");
        }
        
        public override void Down()
        {
        }
    }
}
