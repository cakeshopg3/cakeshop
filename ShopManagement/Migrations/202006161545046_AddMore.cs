namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMore : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.country",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        country_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.products", "country_id", c => c.Int());
            AddColumn("dbo.products", "city_id", c => c.Int());
            AddColumn("dbo.products", "district_id", c => c.Int());
            AddColumn("dbo.products", "ward_id", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.products", "ward_id");
            DropColumn("dbo.products", "district_id");
            DropColumn("dbo.products", "city_id");
            DropColumn("dbo.products", "country_id");
            DropTable("dbo.country");
        }
    }
}
