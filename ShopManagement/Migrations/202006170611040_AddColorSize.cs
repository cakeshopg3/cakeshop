namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColorSize : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.products", "size_id", c => c.Int());
            AddColumn("dbo.products", "color_id", c => c.Int());
            DropColumn("dbo.products", "country_id");
            DropColumn("dbo.products", "city_id");
            DropColumn("dbo.products", "district_id");
            DropColumn("dbo.products", "ward_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.products", "ward_id", c => c.Int());
            AddColumn("dbo.products", "district_id", c => c.Int());
            AddColumn("dbo.products", "city_id", c => c.Int());
            AddColumn("dbo.products", "country_id", c => c.Int());
            DropColumn("dbo.products", "color_id");
            DropColumn("dbo.products", "size_id");
        }
    }
}
