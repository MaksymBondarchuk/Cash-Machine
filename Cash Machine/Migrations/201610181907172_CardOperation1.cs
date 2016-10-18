namespace Cash_Machine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardOperation1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardOperations",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        CardId = c.Guid(nullable: false),
                        OperationTypeId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.OperationTypes", t => t.OperationTypeId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.OperationTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardOperations", "OperationTypeId", "dbo.OperationTypes");
            DropForeignKey("dbo.CardOperations", "CardId", "dbo.Cards");
            DropIndex("dbo.CardOperations", new[] { "OperationTypeId" });
            DropIndex("dbo.CardOperations", new[] { "CardId" });
            DropTable("dbo.CardOperations");
        }
    }
}
