namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllMigrationsInOneMig : DbMigration
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
            CreateTable(
                "Nom.Gender",
                c => new
                    {
                        GenderId = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.GenderId);
            
            CreateTable(
                "Nom.Level",
                c => new
                    {
                        LevelId = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.LevelId);
            
            CreateTable(
                "Hr.Project",
                c => new
                    {
                        ProjectId = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        Description = c.String(maxLength: 250),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "Hr.EmployeeProject",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false),
                        ProjectId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.EmployeeId, t.ProjectId })
                .ForeignKey("HR.Employee", t => t.EmployeeId)
                .ForeignKey("Hr.Project", t => t.ProjectId)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            AddColumn("HR.Department", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("HR.Employee", "LevelId", c => c.Long());
            AddColumn("HR.Employee", "GenderId", c => c.Long());
            AddColumn("HR.Employee", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("HR.Job", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("HR.Location", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterColumn("HR.Department", "DepartmentName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("HR.Employee", "FirstName", c => c.String(maxLength: 250));
            AlterColumn("HR.Employee", "LastName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("HR.Employee", "Email", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("HR.Employee", "PhoneNumber", c => c.String(maxLength: 250));
            AlterColumn("HR.Employee", "Salary", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AlterColumn("HR.Employee", "CommissionPct", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("HR.Employee", "JobId", c => c.Long(nullable: false));
            AlterColumn("HR.Job", "JobTitle", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("HR.Job", "MinSalary", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("HR.Job", "MaxSalary", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("HR.Location", "StreetAddress", c => c.String(maxLength: 100));
            AlterColumn("HR.Location", "PostalCode", c => c.String(maxLength: 30));
            AlterColumn("HR.Location", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("HR.Location", "StateProvince", c => c.String(maxLength: 250));
            CreateIndex("HR.Department", "LocationId");
            CreateIndex("HR.Employee", "Email", unique: true, name: "UX_Email");
            CreateIndex("HR.Employee", "JobId");
            CreateIndex("HR.Employee", "ManagerId");
            CreateIndex("HR.Employee", "DepartmentId");
            CreateIndex("HR.Employee", "LevelId");
            CreateIndex("HR.Employee", "GenderId");
            CreateIndex("HR.Location", new[] { "StreetAddress", "PostalCode" }, unique: true, name: "UX_StreetAddressAndPostalCode");
            AddForeignKey("HR.Employee", "GenderId", "Nom.Gender", "GenderId");
            AddForeignKey("HR.Employee", "JobId", "HR.Job", "JobId");
            AddForeignKey("HR.Employee", "LevelId", "Nom.Level", "LevelId");
            AddForeignKey("HR.Employee", "ManagerId", "HR.Employee", "EmployeeId");
            AddForeignKey("HR.Employee", "DepartmentId", "HR.Department", "DepartmentId");
            AddForeignKey("HR.Department", "LocationId", "HR.Location", "LocationId");
        }
        
        public override void Down()
        {
            DropForeignKey("HR.Department", "LocationId", "HR.Location");
            DropForeignKey("HR.Employee", "DepartmentId", "HR.Department");
            DropForeignKey("Hr.EmployeeProject", "ProjectId", "Hr.Project");
            DropForeignKey("Hr.EmployeeProject", "EmployeeId", "HR.Employee");
            DropForeignKey("HR.Employee", "ManagerId", "HR.Employee");
            DropForeignKey("HR.Employee", "LevelId", "Nom.Level");
            DropForeignKey("HR.Employee", "JobId", "HR.Job");
            DropForeignKey("HR.Employee", "GenderId", "Nom.Gender");
            DropIndex("Hr.EmployeeProject", new[] { "ProjectId" });
            DropIndex("Hr.EmployeeProject", new[] { "EmployeeId" });
            DropIndex("HR.Location", "UX_StreetAddressAndPostalCode");
            DropIndex("HR.Employee", new[] { "GenderId" });
            DropIndex("HR.Employee", new[] { "LevelId" });
            DropIndex("HR.Employee", new[] { "DepartmentId" });
            DropIndex("HR.Employee", new[] { "ManagerId" });
            DropIndex("HR.Employee", new[] { "JobId" });
            DropIndex("HR.Employee", "UX_Email");
            DropIndex("HR.Department", new[] { "LocationId" });
            AlterColumn("HR.Location", "StateProvince", c => c.String());
            AlterColumn("HR.Location", "City", c => c.String());
            AlterColumn("HR.Location", "PostalCode", c => c.String());
            AlterColumn("HR.Location", "StreetAddress", c => c.String());
            AlterColumn("HR.Job", "MaxSalary", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("HR.Job", "MinSalary", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("HR.Job", "JobTitle", c => c.String());
            AlterColumn("HR.Employee", "JobId", c => c.Long());
            AlterColumn("HR.Employee", "CommissionPct", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("HR.Employee", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("HR.Employee", "PhoneNumber", c => c.String());
            AlterColumn("HR.Employee", "Email", c => c.String());
            AlterColumn("HR.Employee", "LastName", c => c.String());
            AlterColumn("HR.Employee", "FirstName", c => c.String());
            AlterColumn("HR.Department", "DepartmentName", c => c.String());
            DropColumn("HR.Location", "RowVersion");
            DropColumn("HR.Job", "RowVersion");
            DropColumn("HR.Employee", "RowVersion");
            DropColumn("HR.Employee", "GenderId");
            DropColumn("HR.Employee", "LevelId");
            DropColumn("HR.Department", "RowVersion");
            DropTable("Hr.EmployeeProject");
            DropTable("Hr.Project");
            DropTable("Nom.Level");
            DropTable("Nom.Gender");
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
