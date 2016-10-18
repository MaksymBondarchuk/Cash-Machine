namespace Cash_Machine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tests", "ForeignTestId", "dbo.ForeignTests");
            DropIndex("dbo.Tests", new[] { "ForeignTestId" });
            DropTable("dbo.ForeignTests");
            DropTable("dbo.Tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Name = c.String(),
                        ForeignTestId = c.Guid(nullable: false),
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
            
            CreateIndex("dbo.Tests", "ForeignTestId");
            AddForeignKey("dbo.Tests", "ForeignTestId", "dbo.ForeignTests", "Id", cascadeDelete: true);
        }
    }
}
