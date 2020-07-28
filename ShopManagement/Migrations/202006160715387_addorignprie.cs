namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addorignprie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.products", "isPopular", c => c.Boolean(nullable: false));
            AddColumn("dbo.products", "origin_price", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.products", "origin_price");
            DropColumn("dbo.products", "isPopular");
        }
    }
}
