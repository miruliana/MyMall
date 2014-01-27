namespace ShopDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClothesSubCategories", "ProductsId", "dbo.Clothes");
            DropForeignKey("dbo.CosmeticSubCategories", "ProductsId", "dbo.Cosmetic");
            DropIndex("dbo.ClothesSubCategories", new[] { "ProductsId" });
            DropIndex("dbo.CosmeticSubCategories", new[] { "ProductsId" });
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Clothes", "TypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Clothes", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Cosmetic", "CategoryId", c => c.Int(nullable: false));
            DropTable("dbo.ClothesSubCategories");
            DropTable("dbo.CosmeticSubCategories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.CosmeticSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductsId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Sequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ClothesSubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductsId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        Sequence = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Cosmetic", "CategoryId");
            DropColumn("dbo.Clothes", "CategoryId");
            DropColumn("dbo.Clothes", "TypeId");
            DropTable("dbo.ProductType");
            CreateIndex("dbo.CosmeticSubCategories", "ProductsId");
            CreateIndex("dbo.ClothesSubCategories", "ProductsId");
            AddForeignKey("dbo.CosmeticSubCategories", "ProductsId", "dbo.Cosmetic", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ClothesSubCategories", "ProductsId", "dbo.Clothes", "Id", cascadeDelete: true);
        }
    }
}
