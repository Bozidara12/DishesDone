namespace Izpitvane8.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dishes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameDish = c.String(),
                        Description = c.String(),
                        Price = c.Int(nullable: false),
                        Weight = c.Double(nullable: false),
                        DishTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DishTypes", t => t.DishTypeID, cascadeDelete: true)
                .Index(t => t.DishTypeID);
            
            CreateTable(
                "dbo.DishTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dishes", "DishTypeID", "dbo.DishTypes");
            DropIndex("dbo.Dishes", new[] { "DishTypeID" });
            DropTable("dbo.DishTypes");
            DropTable("dbo.Dishes");
        }
    }
}
