namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBirthDateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.customers", "BirthDate", c => c.DateTime());
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.customers", "DateofBirth", c => c.DateTime(nullable: false));
            
        }
    }
}
