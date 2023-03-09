namespace ToThanhQui_2080601394.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InsertCategoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (1,'Developer')");
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (2,'Business')");
            Sql("INSERT INTO CATEGORIES (ID,NAME) VALUES (3,'Marketing')");
        }
        
        public override void Down()
        {
        }
    }
}
