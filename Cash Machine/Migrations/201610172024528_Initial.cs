namespace Cash_Machine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardOperations",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CardId = c.Guid(nullable: false),
                        OperationTypeId = c.Guid(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreatedOn = c.DateTime(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.OperationTypes", t => t.OperationTypeId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.OperationTypeId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsBlocked = c.Boolean(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Password = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OperationTypes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CardOperations", "OperationTypeId", "dbo.OperationTypes");
            DropForeignKey("dbo.CardOperations", "CardId", "dbo.Cards");
            DropIndex("dbo.CardOperations", new[] { "OperationTypeId" });
            DropIndex("dbo.CardOperations", new[] { "CardId" });
            DropTable("dbo.OperationTypes");
            DropTable("dbo.Cards");
            DropTable("dbo.CardOperations");
        }
    }
}
