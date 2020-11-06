using Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositoy
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeDTO>> getEmployees();
        Task<EmployeeDTO> getEmployeeById(int id);
        Task<List<EmployeeDTO>> getEmployeesByHourlySalary();
        Task<List<EmployeeDTO>> getEmployeesByMonthlySalary();
    }
}
