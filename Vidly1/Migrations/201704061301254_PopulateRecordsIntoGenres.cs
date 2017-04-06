namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateRecordsIntoGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('PAYASYOUGO')");
            Sql("INSERT INTO Genres(Name) VALUES('MONTHLY')");
            Sql("INSERT INTO Genres(Name) VALUES('QUARTERLY')");
            Sql("INSERT INTO Genres(Name) VALUES('ANUM')");
        }
        
        public override void Down()
        {
        }
    }
}
