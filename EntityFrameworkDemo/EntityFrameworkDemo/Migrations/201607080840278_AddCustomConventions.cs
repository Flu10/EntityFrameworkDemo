namespace EntityFrameworkDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomConventions : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employees", "FirstName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employees", "LastName", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employees", "Email", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employees", "PhoneNumber", c => c.String(maxLength: 250));
            AlterColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AlterColumn("dbo.Employees", "CommissionPct", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("dbo.Jobs", "JobTitle", c => c.String(nullable: false, maxLength: 35));
            AlterColumn("dbo.Jobs", "MinSalary", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("dbo.Jobs", "MaxSalary", c => c.Decimal(precision: 10, scale: 2));
            AlterColumn("dbo.Locations", "StreetAddress", c => c.String(maxLength: 250));
            AlterColumn("dbo.Locations", "PostalCode", c => c.String(maxLength: 250));
            AlterColumn("dbo.Locations", "City", c => c.String(maxLength: 250));
            AlterColumn("dbo.Locations", "StateProvince", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "StateProvince", c => c.String());
            AlterColumn("dbo.Locations", "City", c => c.String());
            AlterColumn("dbo.Locations", "PostalCode", c => c.String());
            AlterColumn("dbo.Locations", "StreetAddress", c => c.String());
            AlterColumn("dbo.Jobs", "MaxSalary", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Jobs", "MinSalary", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Jobs", "JobTitle", c => c.String());
            AlterColumn("dbo.Employees", "CommissionPct", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Employees", "Salary", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Employees", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Employees", "Email", c => c.String());
            AlterColumn("dbo.Employees", "LastName", c => c.String());
            AlterColumn("dbo.Employees", "FirstName", c => c.String());
            AlterColumn("dbo.Departments", "DepartmentName", c => c.String());
        }
    }
}
