namespace ToThanhQui_2080601394.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addnametotable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
        }
    }
}
