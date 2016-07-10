namespace EntityFrameworkDemo
{
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new HrContext.HrContext())
            {
                Console.WriteLine("Angajati:");
                var emplyees = context.Employees;

                foreach (var employee in emplyees)
                {
                    Console.WriteLine("Angajatul: {0} {1}, cu salariul {2}", employee.FirstName, employee.LastName, employee.Salary);
                }
                Console.ReadKey();


                Console.WriteLine("\n \nLocatii:");
                var locations = context.Locations;

                foreach (var location in locations)
                {
                    Console.WriteLine("Locatie: {0}, cod postal: {1}", location.City, location.PostalCode);
                }
                Console.ReadKey();


                Console.WriteLine("\n \nDepartamente:");
                var departments = context.Departments;
                
                foreach (var department in departments)
                {
                    Console.WriteLine("Departament: {0}, locatie departament: {1}", department.DepartmentName, department.Location.City);
                }
                Console.ReadKey();


                Console.WriteLine("\n \nJob-uri:");
                var jobs = context.Jobs;

                foreach (var job in jobs)
                {
                    Console.WriteLine("Departament: {0}", job.JobTitle);
                }
                Console.ReadKey();
            }
        }
    }
}
