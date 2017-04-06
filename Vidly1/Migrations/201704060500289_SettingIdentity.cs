namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingIdentity : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT('Genres', RESEED, 0);");
        }
        
        public override void Down()
        {
        }
    }
}
