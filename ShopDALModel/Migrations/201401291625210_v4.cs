namespace ShopDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CosmeticBrand",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CosmeticCategory",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Clothes", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.Clothes", "Name", c => c.String(maxLength: 255));
            AlterColumn("dbo.Cosmetic", "Code", c => c.String(maxLength: 10));
            AlterColumn("dbo.Cosmetic", "Name", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cosmetic", "Name", c => c.String());
            AlterColumn("dbo.Cosmetic", "Code", c => c.String());
            AlterColumn("dbo.Clothes", "Name", c => c.String());
            AlterColumn("dbo.Clothes", "Code", c => c.String());
            DropTable("dbo.CosmeticCategory");
            DropTable("dbo.CosmeticBrand");
        }
    }
}
