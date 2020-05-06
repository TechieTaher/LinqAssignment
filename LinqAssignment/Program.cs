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
            //---9

            var JohnEmployee = from employee in employees
                            where employee.FirstName == "John"
                            select employee;


            foreach (var emp in JohnEmployee)
            {
                Console.WriteLine(emp.FirstName.IndexOf('o'));
            }
            //---10
            var firstNameWithoutShitespaceRight = employees.Select(t => t.FirstName.TrimStart());

            //---11

            var firstNameWithoutShitespaceLeft = employees.Select(t => t.FirstName.TrimEnd());
            //---12
            var employeeName = from Employee in employees select new { Employee.FirstName };
            foreach (var firstNam in employeeName)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Length of FirstName:" + firstNam.FirstName.Length);
            }
            //---13

            var replaceFirstName = from employee in employees
                             select employee.FirstName.Replace('o', '$');


            foreach (var emp in replaceFirstName)
            {
                Console.WriteLine(emp);
            }
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



            //---17
            var firstNamedesc = employees.OrderByDescending(fName => fName.FirstName);
            foreach (var emp in firstNamedesc)
            {
                Console.WriteLine("\n");
                Console.WriteLine("First Name : " + emp.FirstName);
            }
            //---18
            var firstNameorderby = employees.OrderBy(fName => fName.FirstName);
            foreach (var emp in firstNameorderby)
            {
                Console.WriteLine("\n");
                Console.WriteLine("First Name : " + emp.FirstName);
            }
            //---19

            var empDetail = employees.Where(name => name.FirstName == "John").FirstOrDefault();
            Console.WriteLine("\n");
            Console.WriteLine("FirstName:" + empDetail.FirstName);
            Console.WriteLine("LasrName:" + empDetail.LastName);
            Console.WriteLine("Salary:" + empDetail.Salary);
            Console.WriteLine("JoiningDate:" + empDetail.JoiningDate);
            Console.WriteLine("Department:" + empDetail.Department);
            //---20
            var employeeData = employees.OrderBy(fName => fName.FirstName).ThenByDescending(salary => salary.Salary);
            foreach (var employee in employeeData)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary:" + employee.Salary);
                Console.WriteLine("JoiningDate:" + employee.JoiningDate);
                Console.WriteLine("DEpartment:" + employee.Department);
                Console.WriteLine("\n");
            }

            //---21
            var empDetailJohn = employees.Where(name => name.FirstName != "John" || name.FirstName != "Roy");
            foreach (var employee in empDetailJohn)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary : " + employee.Salary);
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Department : " + employee.Department);
            }
            //---22
                var empDetailJ = employees.Where(name => name.FirstName.StartsWith("J"));
            foreach (var employee in empDetailJ)
            {
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary : " + employee.Salary);
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Department : " + employee.Department);
                Console.WriteLine("\n");
            }

            //---23

            var empDetailo = employees.Where(name => name.FirstName.Contains("o"));
            foreach (var employee in empDetailo)
            {
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary : " + employee.Salary);
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Department : " + employee.Department);
                Console.WriteLine("\n");
            }

            //---24
            var empDetailn = employees.Where(name => name.FirstName.EndsWith("n"));
            foreach (var employee in empDetailn)
            {
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary : " + employee.Salary);
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Department : " + employee.Department);
                Console.WriteLine("\n");
            }
            //--25

            var employeeEndWithN = from employee in employees
                             where employee.FirstName.EndsWith("n") && employee.FirstName.Length == 4
                             select employee;

            foreach (var emp in employeeEndWithN)
            {
                Console.WriteLine(emp.EmployeeId + "-" + emp.FirstName + "-" + emp.LastName + "-" + emp.Salary + "-" + emp.JoiningDate + "-" + emp.Department);
            }

            //---26
            var employeesStartWIthJ = from employee in employees
                             where employee.FirstName.StartsWith("J") && employee.FirstName.Length == 4
                             select employee;

            foreach (var emp in employeesStartWIthJ)
            {
                Console.WriteLine(emp.EmployeeId + "-" + emp.FirstName + "-" + emp.LastName + "-" + emp.Salary + "-" + emp.JoiningDate + "-" + emp.Department);
            }

            //---27

            var empquery27 = from employee in employees
                             where employee.Salary > 60000
                             select employee;

            foreach (var emp in empquery27)
            {
                Console.WriteLine(emp.EmployeeId + "-" + emp.FirstName + "-" + emp.LastName + "-" + emp.Salary + "-" + emp.JoiningDate + "-" + emp.Department);
            }
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

            //---31

            var empDetail2013 = employees.Where(year => year.JoiningDate.Year == 2013);
            foreach (var employee in empDetail2013)
            {
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary : " + employee.Salary);
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Department : " + employee.Department);
                Console.WriteLine("\n");
            }

            //---32

            DateTime newDate = new DateTime(2013, 01, 31);
            var empDetailDate = employees.Where(joindate => joindate.JoiningDate < newDate);
            foreach (var employee in empDetailDate)
            {
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary : " + employee.Salary);
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Department : " + employee.Department);
                Console.WriteLine("\n");
            }
            //---33

            var empDetailJoiningDate = employees.Where(joindate => joindate.JoiningDate < newDate);
            foreach (var employee in empDetailJoiningDate)
            {
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary : " + employee.Salary);
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Department : " + employee.Department);
                Console.WriteLine("\n");
            }
            //---34

            var empDetailAfter = employees.Where(joindate => joindate.JoiningDate > newDate);
            foreach (var employee in empDetailAfter)
            {
                Console.WriteLine("FirstName:" + employee.FirstName);
                Console.WriteLine("LasrName:" + employee.LastName);
                Console.WriteLine("Salary : " + employee.Salary);
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Department : " + employee.Department);
                Console.WriteLine("\n");
            }
            //---35

            var joindate = from Employee in employees select new { Employee.JoiningDate };
            foreach (var dateofjoin in joindate)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Joining Date:" + dateofjoin.JoiningDate);
            }
            //---36

            foreach (Employee e in employees)
                Console.WriteLine($"Joining Date: {e.JoiningDate.Date} Time in milliseconds : { e.JoiningDate.ToLongTimeString() } ");

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
            var employeeNamee = employees.Where<Employee>(c => c.LastName.Contains("%")).Select(t => t.FirstName).ToList();
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
            //---47
            var DateWiseNoOfEmployee = (from employee in employees
                                group employee by employee.JoiningDate into date
                                select new
                                {
                                    JoiningDate = date.Key,
                                    EmployeeId = date.Count()
                                });
            foreach (var employee in DateWiseNoOfEmployee)
            {
                Console.WriteLine("Joining Date : " + employee.JoiningDate);
                Console.WriteLine("Number of employees : " + employee.EmployeeId);
                Console.WriteLine("\n");
            }
            //---48

            var totalsalarygreterthen = employees.GroupBy(e => e.Department).Select(e => new
            {
                DEPARTMENT = e.Key,
                salary = e.Sum(s => s.Salary)
            }).OrderByDescending(e => e.salary).Where(e => e.salary > 10000);
          
            //---49

            var empData = employees.Join(incentives, emp => emp.EmployeeId, inc => inc.EmployeeId, (emp, inc) => new { emp.FirstName, inc.IncentiveAmount });
            foreach (var empInc in empData)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:" + empInc.FirstName);
                Console.WriteLine("Incentive Amount:" + empInc.IncentiveAmount);
            }
            //---50

            var empDataIncentive = employees.Join(incentives, emp => emp.EmployeeId, inc => inc.EmployeeId, (emp, inc) => new { emp.FirstName, inc.IncentiveAmount }).Where(inc => inc.IncentiveAmount > 3000);
            foreach (var empInc in empData)
            {
                Console.WriteLine("\n");
                Console.WriteLine("FirstName:" + empInc.FirstName);
                Console.WriteLine("Incentive Amount:" + empInc.IncentiveAmount);
            }
            //---51
            
            var employeewithorWithoutIncentive = (from emp in employees
                       join inc in incentives on emp.EmployeeId equals inc.EmployeeId into empInc
                       from r in empInc
                       select new
                       {
                           emp.FirstName,
                           incentiveAmount = r
                       });

            //---52
            var employeewithorWithoutIncentiveZero = (from emp in employees
                       join inc in incentives on emp.EmployeeId equals inc.EmployeeId into empInc
                       from r in empInc
                       select new
                       {
                           emp.FirstName,
                           incentiveAmount = r == null ? 0 : r.IncentiveAmount
                       });

            //---53

            var employeewithIncentive = (from emp in employees
                       join inc in incentives on emp.EmployeeId equals inc.EmployeeId into empInc
                       from r in empInc.DefaultIfEmpty()
                       select new
                       {
                           emp.FirstName,
                           incentiveAmount = r == null ? 0 : r.IncentiveAmount
                       });
            
            //---54
            var Top2Salary = (from emp in employees select emp.Salary).Take(2);

            //---55
            int n = 5;
            var TopnSalary = (from emp in employees select emp.Salary).Take(n);
            //---56

            var SecoundMaxSalary = employees.OrderByDescending(x => x.Salary).Select(x => x.Salary).Distinct().Skip(1).First();

            //---57

            int nMax = 3;
            var nMaxSalary = employees.OrderByDescending(x => x.Salary).Select(x => x.Salary).Distinct().Take(nMax).Skip(nMax - 1).First();

            //---58

            foreach (Employee employee in employees)
            {
                Console.WriteLine($"FirstName : { employee.FirstName }\n LastName: { employee.LastName }\n");
            }
            //---60
            var firstnameemployee = from emp in employees
                       join inc in incentives on emp.EmployeeId equals inc.EmployeeId
                       select emp.FirstName;
            //---61

            var unionofemployee = employees.Select(e => e.EmployeeId).Union(incentives.Select(s => s.EmployeeId)).ToList();
          //---62
            
            var withoutIncentive = employees.Select(x => x.EmployeeId).Except(incentives.Select(y => y.EmployeeId)).ToList();
          //--63  


           //----64

        }
    }
}
