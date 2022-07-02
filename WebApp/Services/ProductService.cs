using System.Data.SqlClient;
using WebApp.Model;

namespace WebApp.Services
{
    public class ProductService : IProductService
    {
        private string SQL_Server = "sqlserver0981.database.windows.net";
        private string SQL_DB = "sqldb";
        private string SQL_user = "sqladmin";
        private string SQL_pwd = "Aditya@1712";

        private readonly IConfiguration config;

        public ProductService(IConfiguration _config)
        {
            config = _config;
        }

        private SqlConnection GetConnection()
        {
            /* SqlConnectionStringBuilder _builder = new SqlConnectionStringBuilder();
             _builder.DataSource = SQL_Server;
             _builder.InitialCatalog = SQL_DB;
             _builder.UserID = SQL_user;
             _builder.Password = SQL_pwd;

             return new SqlConnection(_builder.ConnectionString);*/

            return new SqlConnection(config.GetConnectionString("SQLConnection"));
        }

        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();

            List<Product> products = new List<Product>();

            SqlCommand command = new SqlCommand("select ProductID,ProductName, Quantity from Products", conn);

            conn.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product();
                    product.ProductID = reader.GetInt32(0);
                    product.ProductName = reader.GetString(1);
                    product.Quantity = reader.GetInt32(2);
                    products.Add(product);
                }
            }

            conn.Close();
            return products;

        }


    }
}
