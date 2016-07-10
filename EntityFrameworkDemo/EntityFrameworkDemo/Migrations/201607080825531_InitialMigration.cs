namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Long(nullable: false, identity: true),
                        DepartmentName = c.String(),
                        LocationId = c.Long(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Long(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CommissionPct = c.Decimal(precision: 18, scale: 2),
                        HireDate = c.DateTime(nullable: false),
                        JobId = c.Long(),
                        ManagerId = c.Long(),
                        DepartmentId = c.Long(),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Long(nullable: false, identity: true),
                        JobTitle = c.String(),
                        MinSalary = c.Decimal(precision: 18, scale: 2),
                        MaxSalary = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.JobId);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Long(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        StateProvince = c.String(),
                    })
                .PrimaryKey(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Locations");
            DropTable("dbo.Jobs");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
