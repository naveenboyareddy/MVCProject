namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsSubscribedtocustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.customers", "IsSubscribedToNewsLetter");
        }
    }
}
