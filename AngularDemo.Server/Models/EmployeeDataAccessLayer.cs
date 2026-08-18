using BCrypt.Net;
using Npgsql;
using System.Data;

namespace AngularDemo.Server.Models
{
    public class EmployeeDataAccessLayer
    {
        string connectionString = "Host=localhost;Port=5432;Database=demo;Username=postgres;Password=admin";
        // TODO: вынести в конфиги?
        // Поиск сотрудников
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                List<Employee> lstemployee = new List<Employee>();
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    NpgsqlCommand cmd = new NpgsqlCommand("SELECT id, login, name FROM employees", con);
                    con.Open();
                    NpgsqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        // TODO: переделать, реализовать поиск по фио
                        Employee employee = new Employee();
                        employee.ID = Convert.ToInt32(rdr["id"]);
                        employee.Name = rdr["login"].ToString();
                        employee.Name = rdr["name"].ToString();
                        lstemployee.Add(employee);
                    }
                    con.Close();
                }
                return lstemployee;
            }
            catch
            {
                throw;
            }
        }

        // Добавление сотрудника
        public int AddEmployee(Employee employee)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    string salt = BCrypt.Net.BCrypt.GenerateSalt(12);
                    string hash = BCrypt.Net.BCrypt.HashPassword(employee.Password, salt);
                    // TODO: рефакторинг?
                    // TODO: валидация и защита от sql injection!!
                    NpgsqlCommand cmd = new NpgsqlCommand("INSERT INTO employees (login, password, name, lastname, patronymic, email, salt) VALUES ($1, $2, $3, $4, $5, $6, $7)", con)
                    {
                        Parameters =
                        {
                            new() { Value = employee.Login },
                            new() { Value = hash },
                            new() { Value = employee.Name },
                            new() { Value = employee.Lastname },
                            new() { Value = employee.Patronymic },
                            new() { Value = employee.Email },
                            new() { Value = salt },
                        }
                    };
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particluar employee
        public int UpdateEmployee(Employee employee)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    // TODO
                    /*
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    */
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }

        // Удаление сотрудника
        public int DeleteEmployee(int id)
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(connectionString))
                {
                    // TODO
                    /*
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    */
                }
                return 1;
            }
            catch
            {
                throw;
            }
        }
    }

}
