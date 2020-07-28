namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "country_id", c => c.Int());
            AddColumn("dbo.orders", "city_id", c => c.Int());
            AddColumn("dbo.orders", "district_id", c => c.Int());
            AddColumn("dbo.orders", "ward_id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.orders", "ward_id");
            DropColumn("dbo.orders", "district_id");
            DropColumn("dbo.orders", "city_id");
            DropColumn("dbo.orders", "country_id");
        }
    }
}
