using Dapper;
using EmployeesDapper.Model;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace EmployeesDapper.Services
{
    public class EmployeeService : IEmployeeService
    {

        private string ConnectionString;

        public EmployeeService(IDBConnection connec) 
        {
            ConnectionString = connec.GetConnectionString();
        }

        public SqlConnection Connect()
        {
            return new SqlConnection(ConnectionString);
        }





        public async Task CreateEmployeeAsync(Employee employee)
        {
            SqlConnection sqlConnection = Connect();

            try
            {
                sqlConnection.Open();
                DynamicParameters parameters= new DynamicParameters();
                parameters.Add("Name", employee.Name);
                parameters.Add("CodEmployee", employee.CodEmployee);
                parameters.Add("Email", employee.Email);
                parameters.Add("Age", employee.Age);
                parameters.Add("EntryDate", employee.EntryDate);
                parameters.Add("DepartureDate", employee.DepartureDate);
                await sqlConnection.ExecuteAsync("InsertProcedure", parameters, commandType: System.Data.CommandType.StoredProcedure);
            } catch (Exception ex)
            {
                throw new Exception("Something went wrong when inserting the employee: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }

        

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            SqlConnection sqlConnection = Connect();

            try
            {
                sqlConnection.Open();
                DynamicParameters parameters = new DynamicParameters();
                var employees = await sqlConnection.QueryAsync<Employee>("GetAllProcedure", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return (List<Employee>)employees;
            }
            catch (Exception ex)
            {
                throw new Exception("Something went wrong when retrieving all employees: " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }

        }





        public async Task<Employee> GetEmployeeByIDAsync(int id)
        {
            SqlConnection sqlConnection = Connect();

            try
            {
                sqlConnection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", id);
                var employee = await sqlConnection.QuerySingleAsync<Employee>("GetByIdProcedure", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return employee;
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when retrieving employee with id: {id} " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }



        public async Task UpdateEmployeeAsync(int id, Employee employee)
        {
            SqlConnection sqlConnection = Connect();

            try
            {
                sqlConnection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", id);
                parameters.Add("Name", employee.Name);
                parameters.Add("CodEmployee", employee.CodEmployee);
                parameters.Add("Email", employee.Email);
                parameters.Add("Age", employee.Age);
                parameters.Add("EntryDate", employee.EntryDate);
                parameters.Add("DepartureDate", employee.DepartureDate);
                await sqlConnection.ExecuteAsync("UpdateProcedure", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when updating employee with id: {id} " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }


        public async Task DeleteEmployeeAsync(int id)
        {
            SqlConnection sqlConnection = Connect();

            try
            {
                sqlConnection.Open();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", id);
                await sqlConnection.ExecuteAsync("DeleteProcedure", parameters, commandType: System.Data.CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw new Exception($"Something went wrong when deleting employee with id: {id} " + ex.Message);
            }
            finally
            {
                sqlConnection.Close();
                sqlConnection.Dispose();
            }
        }




    }
}
