using System.Net;
using System.Reflection;
using System.Xml.Linq;

namespace EmployeePayrollProblem
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            EmployeePayrollServises employeePayrollServices = new EmployeePayrollServises();
            bool flag = true;
            while (flag)
            {
                Console.Write("Enter the option : 1.AddEmployeePayroll \n 2.RetrieveEntriesFromEmployeePayDB\n3.UpdateDataInDatabase\n4.DeleteDataFromDatabase");
                int option = Convert.ToInt16(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        EmployeePayroll employee = new EmployeePayroll()
                        {
                            ID = 1,
                            Name = "Amit",
                            PhoneNumber = "123456789",
                            Address = "Rampuri Colony",
                            Gender = "M",
                            Start = DateTime.Now
                        };
                        employeePayrollServices.AddEmployeeInDB(employee);
                        break;
                    case 2:
                        employeePayrollServices.RetrieveEntriesFromEmployeePayDB();
                        break;
                    case 3:
                        EmployeePayroll employeePayroll = new EmployeePayroll
                        {
                            Name = "Amit",
                            Address = "Odisha",
                            PhoneNumber = "9090909090",
                        };
                        employeePayrollServices.UpdateDataInDatabase(employeePayroll);
                        break;
                    case 4:
                        employeePayrollServices.DeleteDataFromDatabase("Amit");
                        break;
                    default:
                        flag = false;
                        break;
                }
            }

        }
    }
}
