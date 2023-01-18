using EmployeePayrollProblem;
namespace EmployeePayrollServiceTestCase
{
    [TestClass]
    public class UnitTest1
    {
        EmployeePayrollServises employeePayrollServices = new EmployeePayrollServises();
        [TestMethod]
        public void GivenEmployeeInfo_AbleToAdd()
        {
            EmployeePayroll employee = new EmployeePayroll()
            {
                ID = 1,
                Name = "Amit",
                PhoneNumber = "123456789",
                Address = "Rampuri Colony",
                Gender = "M",
                Start = DateTime.Now
            };
            string result = employeePayrollServices.AddEmployeeInDB(employee);
            Assert.AreEqual("Employee Added Successfully", result);
        }
        [TestMethod]
        public void GivenColumnName_AbleToRetriveDataFromDB()
        {
            string result = employeePayrollServices.RetrieveEntriesFromEmployeePayDB();
            Assert.AreEqual("Retrive SucessFull", result);
        }
        [TestMethod]
        public void GivenPesonInfo_AbleToUpdateDetailsOfPersonInfoInDB()
        {
            EmployeePayroll employeePayroll = new EmployeePayroll
            {
                Name = "Amit",
                Address = "Odisha",
                PhoneNumber = "9090909090",
            };
            string result = employeePayrollServices.UpdateDataInDatabase(employeePayroll);
            Assert.AreEqual("Employee Updated Successfully", result);
        }
        [TestMethod]
        public void GivenEmployeeName_AbleToDeleteDetailsOfEmployeeInfoInDB()
        {
            string result = employeePayrollServices.DeleteDataFromDatabase("Amit");
            Assert.AreEqual("Employee Deleted Successfully", result);
        }
    }
}