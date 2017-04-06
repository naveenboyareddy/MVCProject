namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletingRecordsFromGenres : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Genres");
        }
        
        public override void Down()
        {
        }
    }
}
