namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMore3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.city",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        country_id = c.Int(),
                        city_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.district",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        country_id = c.Int(),
                        city_id = c.Int(),
                        district_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ward",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        country_id = c.Int(),
                        city_id = c.Int(),
                        district_id = c.Int(),
                        ward_name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ward");
            DropTable("dbo.district");
            DropTable("dbo.city");
        }
    }
}
