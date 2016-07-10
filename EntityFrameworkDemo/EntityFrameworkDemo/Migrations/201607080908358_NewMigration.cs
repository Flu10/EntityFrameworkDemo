namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Departments", newName: "Department");
            RenameTable(name: "dbo.Employees", newName: "Employee");
            RenameTable(name: "dbo.Jobs", newName: "Job");
            RenameTable(name: "dbo.Locations", newName: "Location");
            MoveTable(name: "dbo.Department", newSchema: "HR");
            MoveTable(name: "dbo.Employee", newSchema: "HR");
            MoveTable(name: "dbo.Job", newSchema: "HR");
            MoveTable(name: "dbo.Location", newSchema: "HR");
            AlterColumn("HR.Department", "DepartmentName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("HR.Employee", "LastName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("HR.Employee", "Email", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("HR.Employee", "JobId", c => c.Long(nullable: false));
            AlterColumn("HR.Location", "City", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("HR.Department", "LocationId");
            CreateIndex("HR.Employee", "JobId");
            CreateIndex("HR.Employee", "ManagerId");
            CreateIndex("HR.Employee", "DepartmentId");
            AddForeignKey("HR.Department", "LocationId", "HR.Location", "LocationId");
            AddForeignKey("HR.Employee", "DepartmentId", "HR.Department", "DepartmentId");
            AddForeignKey("HR.Employee", "JobId", "HR.Job", "JobId");
            AddForeignKey("HR.Employee", "ManagerId", "HR.Employee", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("HR.Employee", "ManagerId", "HR.Employee");
            DropForeignKey("HR.Employee", "JobId", "HR.Job");
            DropForeignKey("HR.Employee", "DepartmentId", "HR.Department");
            DropForeignKey("HR.Department", "LocationId", "HR.Location");
            DropIndex("HR.Employee", new[] { "DepartmentId" });
            DropIndex("HR.Employee", new[] { "ManagerId" });
            DropIndex("HR.Employee", new[] { "JobId" });
            DropIndex("HR.Department", new[] { "LocationId" });
            AlterColumn("HR.Location", "City", c => c.String(maxLength: 250));
            AlterColumn("HR.Employee", "JobId", c => c.Long());
            AlterColumn("HR.Employee", "Email", c => c.String(maxLength: 250));
            AlterColumn("HR.Employee", "LastName", c => c.String(maxLength: 250));
            AlterColumn("HR.Department", "DepartmentName", c => c.String(maxLength: 250));
            MoveTable(name: "HR.Location", newSchema: "dbo");
            MoveTable(name: "HR.Job", newSchema: "dbo");
            MoveTable(name: "HR.Employee", newSchema: "dbo");
            MoveTable(name: "HR.Department", newSchema: "dbo");
            RenameTable(name: "dbo.Location", newName: "Locations");
            RenameTable(name: "dbo.Job", newName: "Jobs");
            RenameTable(name: "dbo.Employee", newName: "Employees");
            RenameTable(name: "dbo.Department", newName: "Departments");
        }
    }
}
