using SoftUni.Data;
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
    }
}
 