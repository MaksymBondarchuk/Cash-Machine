namespace Cash_Machine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cards", "Pin", c => c.String());
            DropColumn("dbo.Cards", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cards", "Password", c => c.String());
            DropColumn("dbo.Cards", "Pin");
        }
    }
}
