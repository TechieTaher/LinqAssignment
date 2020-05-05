using LinqAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            //---1
            List<Employee> employees = new List<Employee>(){
                new Employee(){EmployeeId = 1,FirstName="Taher",LastName="Dahodwala",Salary=5000,JoiningDate=Convert.ToDateTime(20/1/2020),Department=".net"},
                new Employee(){EmployeeId = 2,FirstName="Sandip",LastName="Dankhra",Salary=10000,JoiningDate=Convert.ToDateTime(20/1/2020),Department="php"},
                new Employee(){EmployeeId = 3,FirstName="Hardik",LastName="Makwana",Salary=15000,JoiningDate=Convert.ToDateTime(20/1/2020),Department="QA"}
           };
            List<Incentive> incentives = new List<Incentive>() {
                new Incentive(){IncentiveId=1,EmployeeId=1,IncentiveAmount=1000,IncentiveDate=Convert.ToDateTime(20/2/2020)},
                new Incentive(){IncentiveId=2,EmployeeId=2,IncentiveAmount=1000,IncentiveDate=Convert.ToDateTime(20/2/2020)},
                new Incentive(){IncentiveId=3,EmployeeId=3,IncentiveAmount=1000,IncentiveDate=Convert.ToDateTime(20/2/2020)}
            };



//-- 2

            var allemployee = from employee in employees
                            select new
                            {
                                employee.EmployeeId,
                                employee.FirstName,
                                employee.LastName,
                                employee.Salary,
                                employee.JoiningDate,
                                employee.Department
                            };
            //--3

            var FullName = from employee in employees
                            select new
                            {
                                employee.FirstName,
                                employee.LastName,
                            };
            
            

            //--4

            var Firstname = from employee in employees
                            select new
                            {
                                employeeName = employee.FirstName
                            };

            

            //--5

            var UpperCaseFirstname = from employee in employees
                            select new
                            {
                                employeeName = employee.FirstName.ToUpper()
                            };
            
            

            //--6--

            var LowercaseFirstName = from employee in employees
                            select new
                            {
                                employeeName = employee.FirstName.ToLower()
                            };



            //--7--

            var AllDepartment = from employee in employees
                                select new
                                {
                                    department = employee.Department.Distinct()
                                };
                           
            
            

            //--8--

            var firstName = from employee in employees
                            select new
                            {
                                Latters = employee.FirstName.Substring(0, 3)
                            };
            
            

            //--14--

            var singleColumn = from employee in employees
                               select new
                               {
                                   Name = employee.FirstName + '_' + employee.LastName
                               };

            
            

            //--15--

            var joininginfo = from employee in employees
                              select new
                              {
                                  employee.FirstName,
                                  employee.JoiningDate
                              };

            
            

            //--16--

            var orderdEmployee = from employee in employees
                            orderby (employee.FirstName)
                            select new
                            {
                                employee.EmployeeId,
                                employee.FirstName,
                                employee.LastName,
                                employee.Salary,
                                employee.JoiningDate,
                                employee.Department
                            };

            
            


            //--28--

            var salarycondition = from employee in employees
                            where employee.Salary < 800000
                            select new
                            {
                                employee.EmployeeId,
                                employee.FirstName,
                                employee.LastName,
                                employee.Salary,
                                employee.JoiningDate,
                                employee.Department
                            };
            
            

            //--29--

            var salaryconditions = from employee in employees
                            where employee.Salary > 500000 && employee.Salary < 800000
                            select new
                            {
                                employee.EmployeeId,
                                employee.FirstName,
                                employee.LastName,
                                employee.Salary,
                                employee.JoiningDate,
                                employee.Department
                            };
            
            

            //--30--

            var JohnMichael = from employee in employees
                            where employee.FirstName == "John" || employee.FirstName == "Michael"
                            select new
                            {
                                employee.EmployeeId,
                                employee.FirstName,
                                employee.LastName,
                                employee.Salary,
                                employee.JoiningDate,
                                employee.Department
                            };
            
            
            //---37
            var dates = from employee in employees
                        join incentive in incentives on employee.EmployeeId equals incentive.EmployeeId
                        select new { employee.JoiningDate, incentive.IncentiveDate };
            List<double> diffdate = new List<double>();
            foreach (var item in dates)
            {
                double date = (item.JoiningDate - item.IncentiveDate).TotalDays;
                diffdate.Add(date);
            }
            //---39
            var employeeName = employees.Where<Employee>(c => c.LastName.Contains("%")).Select(t => t.FirstName).ToList();
            //--40
            var lastName = employees.Select(t => t.LastName.Replace(@"[^\w\d]", " "));
            //---41
            var totalSalary = employees.GroupBy(t => t.Department).Select(t=>t.Sum(t=>t.Salary));
            //---42
            var totalSalaryDesc = (from employee in employees
                                   group employee by new { employee.Department } into department
                                   select new { department,
                                   totalSalary = department.Sum(s=>s.Salary)}).OrderByDescending(t => t.totalSalary);
            //---43
             var totalSalaryemployee = (from employee in employees
                                   group employee by new { employee.Department } into department
                                   select new { department,
                                   noOfemployee = department.Count(),
                                   totalSalary = department.Sum(s=>s.Salary)}).OrderByDescending(t => t.totalSalary);
            //---44 
            var averageSalary = (from employee in employees
                                   group employee by new { employee.Department } into department
                                   select new { department,
                                   averageSalary = department.Average(s=>s.Salary)}).OrderByDescending(t => t.averageSalary);
            //---45
            var maxSalary = (from employee in employees
                                   group employee by new { employee.Department } into department
                                   select new { department,
                                   averageSalary = department.Max(s=>s.Salary)}).OrderByDescending(t => t.averageSalary);
            //---46
            var minSalary = (from employee in employees
                                   group employee by new { employee.Department } into department
                                   select new { department,
                                   averageSalary = department.Min(s=>s.Salary)}).OrderByDescending(t => t.averageSalary);

        }
    }
}
