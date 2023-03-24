namespace ToThanhQui_2080601394.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsCancelColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "IsCancel", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "IsCancel");
        }
    }
}
