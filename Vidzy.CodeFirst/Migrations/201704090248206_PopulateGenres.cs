namespace Vidzy.CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres (Id, Name) Values (1, 'Comedy')");
            Sql("INSERT INTO Genres (Id, Name) Values (2, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) Values (3, 'Horror')");
        }

        public override void Down()
        {
            Sql("TRUNCATE TABLE Genres");
        }
    }
}
