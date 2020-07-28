namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProperty : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.category",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        category_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        customer_name = c.String(nullable: false, maxLength: 255),
                        phone_number = c.String(maxLength: 255),
                        address_shipping = c.String(maxLength: 255),
                        note = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.orders_item",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        order_id = c.Long(nullable: false),
                        book_id = c.Long(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, storeType: "money"),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.products",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        product_name = c.String(maxLength: 50),
                        category = c.Int(),
                        price = c.Decimal(storeType: "money"),
                        image_url = c.String(),
                        description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.users",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        user_name = c.String(maxLength: 30, unicode: false),
                        password = c.String(maxLength: 50, unicode: false),
                        user_role = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.users");
            DropTable("dbo.products");
            DropTable("dbo.orders_item");
            DropTable("dbo.orders");
            DropTable("dbo.category");
        }
    }
}
