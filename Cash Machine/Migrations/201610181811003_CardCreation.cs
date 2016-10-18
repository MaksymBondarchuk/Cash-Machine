namespace Cash_Machine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CardCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        IsBlocked = c.Boolean(nullable: false),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Password = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ForeignTests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        ForeignTestId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ForeignTests", t => t.ForeignTestId, cascadeDelete: true)
                .Index(t => t.ForeignTestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tests", "ForeignTestId", "dbo.ForeignTests");
            DropIndex("dbo.Tests", new[] { "ForeignTestId" });
            DropTable("dbo.Tests");
            DropTable("dbo.ForeignTests");
            DropTable("dbo.Cards");
        }
    }
}
