namespace ProgramowanieInternetowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MissingPersonModelAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MissingPersonModels",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MissingPersonModels");
        }
    }
}
