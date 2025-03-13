using SoftUni.Data;
using SoftUni.Models;
using System.Globalization;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using SoftUniContext dbContext = new SoftUniContext();
            dbContext.Database.EnsureCreated();

            string result = GetEmployeesFullInformation(dbContext);
            Console.WriteLine(result);
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary.ToString("F2")}");
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 04

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select(e => new
                {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary.ToString("F2")}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 05

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.Department.Name.Equals("Research and Development"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepatmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from Research and Development - ${e.Salary.ToString("F2")}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 06

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            const string newAddressText = "Vitoshka 15";
            const int newAddressTownId = 4;

            Address newAddress = new Address()
            {
                AddressText = newAddressText,
                TownId = newAddressTownId
            };

            Employee nakovEmployee = context
                .Employees
                .First(e => e.LastName.Equals("Nakov"));
            nakovEmployee.Address = newAddress;

            context.SaveChanges();

            string?[] addresses = context
                .Employees
                .Where(e => e.AddressId.HasValue)
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address!.AddressText)
                .Take(10)
                .ToArray();

            return String.Join(Environment.NewLine, addresses);
        }
        //Problem 07
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesWithProject = context
                .Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager == null ? null : e.Manager.FirstName,
                    ManagerLastName = e.Manager == null ? null : e.Manager.LastName,
                    Projects = e.EmployeesProjects
                    .Select(ep => ep.Project)
                    .Where(p => p.StartDate.Year >= 2001 && p.StartDate.Year <= 2003)
                    .Select(p => new
                    {
                        ProjectName = p.Name,
                        p.StartDate,
                        p.EndDate
                    })
                    .ToArray()
                })
                .Take(10)
                .ToArray();

            foreach (var e in employeesWithProject)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");
                foreach (var p in e.Projects)
                {
                    string startDateFormatted = p.StartDate
                       .ToString("M/d/yyyy h:mm:ss tt");
                    string endDateFormatted = p.EndDate.HasValue ?
                        p.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt") : "not finished";
                    sb
                        .AppendLine($"--{p.ProjectName} - {startDateFormatted} - {endDateFormatted}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        //Problem 08
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                {
                    TownName = a.Town.Name,
                    a.AddressText,
                    EmployeesCount = a.Employees.Count,
                })
                .OrderByDescending(e => e.EmployeesCount)
                .ThenBy(a => a.TownName)
                 .ThenBy(a => a.AddressText)
                .Take(10)
                .ToList();

            foreach (var a in addresses)
            {
                sb.AppendLine($"{a.AddressText}, {a.TownName} - {a.EmployeesCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 09
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var employees = context
                .Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                    .Select(p => new
                    {
                        ProjectName = p.Project.Name
                    }).OrderBy(p => p.ProjectName).ToList()
                }).FirstOrDefault();

            sb.AppendLine($"{employees.FirstName} {employees.LastName} - {employees.JobTitle}");

            foreach (var project in employees.Projects)
            {
                sb.AppendLine(project.ProjectName);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();
            var departments = context
                .Departments
                .Where(d => d.Employees.Count > 5)
                .OrderBy(d => d.Employees.Count)
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerInfo = context.Employees.Where(m => m.EmployeeId == d.ManagerId)
                        .Select(m => new
                        {
                            m.FirstName,
                            m.LastName
                        }).FirstOrDefault(),
                    EmployeesInfo = d.Employees
                        .Select(e => new
                        {
                            e.FirstName,
                            e.LastName,
                            e.JobTitle
                        }).OrderBy(e => e.FirstName).ThenBy(e => e.LastName).ToList()
                }).ToList();
            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerInfo.FirstName} {department.ManagerInfo.LastName}");

                foreach (var employee in department.EmployeesInfo)
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();

        }

        //Problem 11
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(d => d.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                }).ToArray();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine($"{project.StartDate}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 12
        public static string IncreaseSalaries(SoftUniContext context)
        {

            string[] allowedDepartments = new string[] { "Engineering", "Tool Design", "Marketing", "Information Services" };

            var employeesWithIncreasedSalaries = context.Employees
                .Where(e => allowedDepartments.Contains(e.Department.Name))
                .ToArray();

            foreach (var employee in employeesWithIncreasedSalaries)
            {
                employee.Salary *= 1.12m;
            }
            context.SaveChanges();

            var employeesInfo = context
                .Employees
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Where(e => allowedDepartments.Contains(e.Department.Name))
                .Select(e => $"{e.FirstName} {e.LastName} (${e.Salary:f2})")
                .ToList();


            return string.Join(Environment.NewLine, employeesInfo).TrimEnd();
        }

        //Problem 13
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {

            var employees = context
                .Employees          
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .Where(e => e.FirstName.ToLower().StartsWith("sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => $"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:f2})")
                .ToArray();

            return string.Join(Environment.NewLine, employees).TrimEnd();
        }

        //Problem 14
        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectToDeleteFromEmployeesProjects = context.EmployeesProjects.Where(ep => ep.ProjectId == 2);
            context.EmployeesProjects.RemoveRange(projectToDeleteFromEmployeesProjects);

            var projectToDeleteFromProjects = context.Projects.Where(p => p.ProjectId == 2);
            context.Projects.RemoveRange(projectToDeleteFromProjects);

            context.SaveChanges();

            var projectsText = context.Projects
                .Take(10)
                .Select(p => $"{p.Name}")
                .ToList();

            return string.Join(Environment.NewLine, projectsText);
        }

        //Problem 15
        public static string RemoveTown(SoftUniContext context)
        {
            Town townToDelete = context.Towns.Where(t => t.Name == "Seattle").FirstOrDefault();

            Address[] addressesToDelete = context.Addresses.Where(a => a.TownId == townToDelete.TownId).ToArray();

            Employee[] employeesToRemoveAddressFrom = context.Employees.Where(e => addressesToDelete.Contains(e.Address)).ToArray();

            foreach (var employee in employeesToRemoveAddressFrom)
            {
                employee.AddressId = null;
            }

            context.Addresses.RemoveRange(addressesToDelete);
            context.Towns.RemoveRange(townToDelete);

            context.SaveChanges();

            return $"{addressesToDelete.Count()} addresses in Seattle were deleted";
        }
    }
}
 