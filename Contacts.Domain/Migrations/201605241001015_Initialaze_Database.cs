namespace Contacts.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialaze_Database : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Gender = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        CompanyName = c.String(),
                        JobTitle = c.String(),
                        Phone = c.String(),
                        Avatar = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacts");
        }
    }
}
