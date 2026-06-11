using Microsoft.Data.SqlClient;
using System.Data;

namespace MyWebApp.DatabaseHelper
{
    public static class DatabaseSql
    {
        private static String connectionString = "Data Source=SAMUEL\\SQLEXPRESS;Database=AdventureWorks2025;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name=\"MyApp\";Command Timeout=0";
        private static SqlConnection conn;

        public static SqlConnection getConnection()
        {
            return conn;
        }

        public static DataTable executeStoredProcedure(string sp, List<SqlParameter> parameters)
        {
            using (conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = sp;
                cmd.Connection = conn;

                if (parameters != null)
                {
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                }

                cmd.ExecuteNonQuery();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                return dt;
            }
        }
    }
}
