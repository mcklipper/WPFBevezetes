using System;
using System.Data.SqlClient;

namespace WPFBevezetes.Models
{
    public static class DataBaseHandler
    {
        static SqlConnection connection;

        static DataBaseHandler()
        {
            connection = new(@"Data Source=(localdb)\MSSQLLocalDB; " +
                "Initial Catalog=Wpfbev; Integrated Security=True;");
        }

        static bool RegistrateUser(object model)
        {
            try
            {
                connection.Open();

                SqlDataAdapter adapter = new()
                {
                    InsertCommand = new($"INSERT INTO users (id, username, email, password) VALUES " +
                        $"('{ Guid.NewGuid() }', '{ model.ToString() }', '{ model.ToString() }', '{ model.ToString() }')", connection)
                };
                adapter.InsertCommand.ExecuteNonQuery();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
