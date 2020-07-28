namespace ShopManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.category", "image_url", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.category", "image_url");
        }
    }
}
