namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class PopulateRecordsInGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('COMEDY')");
            Sql("INSERT INTO Genres(Name) VALUES('ACTION')");
            Sql("INSERT INTO Genres(Name) VALUES('ROMANCE')");
            Sql("INSERT INTO Genres(Name) VALUES('FAMILY')");
        }

        public override void Down()
        {
        }

    }
}