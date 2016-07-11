namespace EntityFrameworkDemo
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.SqlClient;
    using System.Linq;
    using Model;
    using System.Collections.Generic;

    public class Program
    {
        static void Main(string[] args)
        {
            using (var context = new HrContext.HrContext())
            {

                #region lazy eager explicit
                /* Lazy, Eager, Explicit cu lazy, proxy - true false
                //Lazy = true:
                var firstEmployee = context.Employees.First();
                //Lazy = false: (incercati si cu proxy true si cu proxy false)
                var firstEmployee2 = context.Employees.Include(x => x.Department).Include(x => x.Job).First();
                var dep = firstEmployee2.Department;
                // Explicit loading: (lazy = false)
                context.Entry(firstEmployee).Reference(s => s.Department).Load();

                // Inverse property: - lazy true:
                var departament = context.Departments.First(x => x.DepartmentName == "Marketing");
                var employees = departament.Employees.ToList();
                foreach (var employee in employees)
                {
                    Console.WriteLine(employee.FullName);
                }
                */
                #endregion


                #region inverse property
                var departament2 = context.Departments.Include(x => x.Employees).FirstOrDefault(x => x.DepartmentName == "IT");
                if (departament2 != null)
                {
                    var employees2 = departament2.Employees.ToList();
                    foreach (var employee2 in employees2)
                    {
                        Console.WriteLine(employee2.FullName);
                    }
                }

                #endregion


                #region Iquerable vs Ienumerable

                var jobs = context.Jobs;
                var jobsList = jobs.ToList();

                #endregion

                #region insert, update, delete

                #region insert
                var newJob = new Job
                {
                    JobTitle = "Mecanic",
                    MaxSalary = 7,
                    MinSalary = 1
                };
                context.Jobs.Add(newJob);
                context.SaveChanges();

                var newJobList = new List<Job>();
                newJobList.Add(newJob);
                newJobList.Add(new Job
                {
                    JobTitle = "Paznic",
                    MinSalary = 1,
                    MaxSalary = 3
                });
                //var newJobList = new List<Job>
                //{
                //    newJob,
                //    new Job
                //    {
                //        JobTitle = "Paznic",
                //        MinSalary = 1,
                //        MaxSalary = 3
                //    }
                //};

                context.Jobs.AddRange(newJobList);
                context.SaveChanges();

                #endregion


                #region update

                newJob.MaxSalary = (decimal)6.5;
                context.Jobs.AddOrUpdate(newJob);
                
                var mecanics = context.Jobs.Where(x => x.JobTitle == "Mecanic").ToList();
                foreach (var m in mecanics)
                {
                    m.MaxSalary = 6;
                    context.Jobs.AddOrUpdate(m);
                }

                context.SaveChanges();

                #endregion


                #region delete

                var anotherJob = context.Jobs.FirstOrDefault(x => x.Id == 20);
                context.Jobs.Remove(newJob);
                if (anotherJob != null)
                {
                    context.Jobs.Remove(anotherJob);
                }


                var jobsToDeleteList = context.Jobs.Where(x => x.Id > 5).ToList();
                context.Jobs.RemoveRange(jobsToDeleteList);
                context.SaveChanges();

                #endregion

                #endregion

                Console.ReadKey();

                var newManager = context.Employees.FirstOrDefault(x => x.FirstName == "Raluca" && x.LastName == "Ionescu");
                if (newManager != null)
                {
                    var newManagerId = new SqlParameter("@NewManagerId", newManager.Id);

                    var employees =
                        context.Database.SqlQuery<Employee>("exec [Hr].[ChangeManager] @NewManagerId", newManagerId)
                            .ToList();

                    foreach (var employee in employees)
                    {
                        Console.WriteLine("Employee: {0} {1}", employee.FirstName, employee.LastName);
                    }

                    //foreach (var employee in context.Employees.ToList())
                    //{
                    //    Console.WriteLine("Employee: {0} {1} {2}", employee.FirstName, employee.LastName,
                    //        employee.Manager != null ? employee.Manager.FullName : String.Empty);
                    //}
                }

                Console.ReadKey();
            }
        }
    }
}
