namespace Cash_Machine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardOperation_Id : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CardOperations");
            AlterColumn("dbo.CardOperations", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.CardOperations", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.CardOperations");
            AlterColumn("dbo.CardOperations", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.CardOperations", "Id");
        }
    }
}
