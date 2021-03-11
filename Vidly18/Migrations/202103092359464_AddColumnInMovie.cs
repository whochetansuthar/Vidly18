namespace Vidly18.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnInMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AvailableStock", c => c.Byte(nullable: false,defaultValue:0));
            Sql("UPDATE Movies set AvailableStock = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AvailableStock");
        }
    }
}
