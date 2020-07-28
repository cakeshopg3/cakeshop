namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSizeTableColorTable2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.colors",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        color_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.sizes",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        size_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.sizes");
            DropTable("dbo.colors");
        }
    }
}
