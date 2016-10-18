namespace Cash_Machine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ForeignTests", "Name", c => c.String());
            AddColumn("dbo.Tests", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tests", "Name");
            DropColumn("dbo.ForeignTests", "Name");
        }
    }
}
