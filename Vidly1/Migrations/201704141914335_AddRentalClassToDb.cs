namespace Vidly1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRentalClassToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Customers_id = c.Int(nullable: false),
                        Movies_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.customers", t => t.Customers_id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movies_Id, cascadeDelete: true)
                .Index(t => t.Customers_id)
                .Index(t => t.Movies_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "Movies_Id", "dbo.Movies");
            DropForeignKey("dbo.Rentals", "Customers_id", "dbo.customers");
            DropIndex("dbo.Rentals", new[] { "Movies_Id" });
            DropIndex("dbo.Rentals", new[] { "Customers_id" });
            DropTable("dbo.Rentals");
        }
    }
}
