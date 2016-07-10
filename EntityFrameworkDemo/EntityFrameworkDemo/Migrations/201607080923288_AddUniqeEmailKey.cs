namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqeEmailKey : DbMigration
    {
        public override void Up()
        {
            AlterColumn("HR.Employee", "Email", c => c.String(nullable: false, maxLength: 35));
            CreateIndex("HR.Employee", "Email", unique: true, name: "UX_Email");
        }
        
        public override void Down()
        {
            DropIndex("HR.Employee", "UX_Email");
            AlterColumn("HR.Employee", "Email", c => c.String(nullable: false, maxLength: 250));
        }
    }
}
