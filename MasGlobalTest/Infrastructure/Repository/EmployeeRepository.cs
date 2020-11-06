using Domain.DTO;
using Domain.Repositoy;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public async Task<EmployeeDTO> getEmployeeById(int id)
        {
            var result = await getEmployeesAll();
            var employee = result.FirstOrDefault(e => e.Id == id);
            return employee;
        }

        public async Task<List<EmployeeDTO>> getEmployees() => await getEmployeesAll();

        private async Task<List<EmployeeDTO>> getEmployeesAll()
        {
            var client = new RestClient("http://masglobaltestapi.azurewebsites.net/api/Employees");
            var request = new RestRequest(Method.GET);
            var response = await client.ExecuteAsync(request);
            var result = JsonConvert.DeserializeObject<List<EmployeeDTO>>(response.Content);
            return result;
        }

        public async Task<List<EmployeeDTO>> getEmployeesByHourlySalary()
        {
            var result = await getEmployeesAll();
            var listEmployees = result.Where(e => e.contractTypeName == "HourlySalary").ToList();
            return listEmployees;
        }

        public async Task<List<EmployeeDTO>> getEmployeesByMonthlySalary()
        {
            var result = await getEmployeesAll();
            var listEmployees = result.Where(e => e.contractTypeName == "MonthlySalary").ToList();
            return listEmployees;
        }
    }
}
