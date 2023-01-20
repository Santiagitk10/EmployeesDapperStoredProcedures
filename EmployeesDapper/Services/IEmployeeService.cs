using EmployeesDapper.Model;

namespace EmployeesDapper.Services
{
    public interface IEmployeeService
    {
        Task CreateEmployeeAsync(Employee employee);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIDAsync(int id);
        Task UpdateEmployeeAsync(int id, Employee employee);
        Task DeleteEmployeeAsync(int id);

    }
}
