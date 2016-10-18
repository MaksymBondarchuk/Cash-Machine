namespace Cash_Machine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CardOperations", "OperationTypeId", "dbo.OperationTypes");
            DropForeignKey("dbo.CardOperations", "CardId", "dbo.Cards");
            DropIndex("dbo.CardOperations", new[] { "OperationTypeId" });
            DropPrimaryKey("dbo.Cards");
            DropPrimaryKey("dbo.OperationTypes");
            CreateTable(
                "dbo.ForeignTests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        ForeignTestId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForeignTests", t => t.ForeignTestId, cascadeDelete: true)
                .Index(t => t.ForeignTestId);
            
            AlterColumn("dbo.Cards", "Id", c => c.Guid(nullable: false, identity: true));
            AlterColumn("dbo.OperationTypes", "Id", c => c.Guid(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cards", "Id");
            AddPrimaryKey("dbo.OperationTypes", "Id");
            AddForeignKey("dbo.CardOperations", "CardId", "dbo.Cards", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardOperations", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Tests", "ForeignTestId", "dbo.ForeignTests");
            DropIndex("dbo.Tests", new[] { "ForeignTestId" });
            DropPrimaryKey("dbo.OperationTypes");
            DropPrimaryKey("dbo.Cards");
            AlterColumn("dbo.OperationTypes", "Id", c => c.Guid(nullable: false));
            AlterColumn("dbo.Cards", "Id", c => c.Guid(nullable: false));
            DropTable("dbo.Tests");
            DropTable("dbo.ForeignTests");
            AddPrimaryKey("dbo.OperationTypes", "Id");
            AddPrimaryKey("dbo.Cards", "Id");
            CreateIndex("dbo.CardOperations", "OperationTypeId");
            AddForeignKey("dbo.CardOperations", "CardId", "dbo.Cards", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CardOperations", "OperationTypeId", "dbo.OperationTypes", "Id", cascadeDelete: true);
        }
    }
}
