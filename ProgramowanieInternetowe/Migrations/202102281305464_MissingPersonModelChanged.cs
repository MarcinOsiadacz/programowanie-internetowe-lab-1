namespace ProgramowanieInternetowe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MissingPersonModelChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MissingPersonModels", "PhotoUrl", c => c.String());
            AlterColumn("dbo.MissingPersonModels", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.MissingPersonModels", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.MissingPersonModels", "Gender", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MissingPersonModels", "Gender", c => c.String());
            AlterColumn("dbo.MissingPersonModels", "LastName", c => c.String());
            AlterColumn("dbo.MissingPersonModels", "FirstName", c => c.String());
            DropColumn("dbo.MissingPersonModels", "PhotoUrl");
        }
    }
}
