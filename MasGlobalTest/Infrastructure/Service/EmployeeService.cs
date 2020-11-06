using Domain.DTO;
using Domain.Repositoy;
using Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<EmployeeDTO> getEmployeeById(int id)
        {
            EmployeeDTO employee = await _repository.getEmployeeById(id);
            if (employee.contractTypeName == "HourlySalaryEmployee")
            {
                employee.annualSalary = 120 * employee.hourlySalary * 12;
            }
            else
            {
                employee.annualSalary = 0;
            }

            if (employee.contractTypeName == "MonthlySalaryEmployee")
            {
                employee.annualSalary = employee.monthlySalary * 12;
            }
            else
            {
                employee.annualSalary = 0;
            }
            return employee;

        }

        public async Task<List<EmployeeDTO>> getEmployees() {
            List<EmployeeDTO>list = await _repository.getEmployees();
            foreach (var employee in list)
            {
                if (employee.contractTypeName == "HourlySalaryEmployee")
                {
                    employee.annualSalary = 120 * employee.hourlySalary * 12;
                }
                else {
                    employee.annualSalary = 0;
                }

                if (employee.contractTypeName == "MonthlySalaryEmployee")
                {
                    employee.annualSalary = employee.monthlySalary * 12;
                }
                else
                {
                    employee.annualSalary = 0;
                }
            }
            return list;
        }

        public async Task<List<EmployeeDTO>> getEmployeesByHourlySalary() {
            List<EmployeeDTO> list = await _repository.getEmployees();
            foreach (var employee in list)
            {
                employee.annualSalary = 120 * employee.hourlySalary * 12;
            }
            return list;
        }

        public async Task<List<EmployeeDTO>> getEmployeesByMonthlySalary()
        {
            List<EmployeeDTO> list = await _repository.getEmployeesByMonthlySalary();
            foreach (var employee in list)
            {
                employee.annualSalary = employee.monthlySalary * 12;
            }
            return list;
            
        }
    }
}
