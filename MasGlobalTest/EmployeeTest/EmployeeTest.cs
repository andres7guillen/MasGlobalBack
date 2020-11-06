using Domain.Service;
using Infrastructure.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeTest
{
    [TestClass]
    public class EmployeeTest
    {
        private readonly IEmployeeService _service;
        public EmployeeTest(IEmployeeService service)
        {
            _service = service;
        }

        [TestMethod]
        public async void getEmployeeById()
        {
            var employee = await _service.getEmployeeById(2);
            Assert.IsNotNull(employee);
        }

        [TestMethod]
        public async void getEmployees()
        {
            var employees = await _service.getEmployees();
            Assert.IsNotNull(employees);
        }
    }
}
