using BenchmarkDotNet.Attributes;
using Microsoft.Data.SqlClient;
using System.Data.Common;
using App.Context;
using App.Model;
using Dapper;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class DbBenchmarks
    {
        static string ConnectionString = "Server=localhost,1433;Database=MyDb;User Id=SA;Password=Passw0rd;TrustServerCertificate=True;";

        MyDbContext efContext = new MyDbContext();
        SqlConnection adoConnection = new SqlConnection(ConnectionString);
        DbConnection dapperConnection = new SqlConnection(ConnectionString);

        private Product testProduct = new Product
        {
            Name = "Test Product",
            Description = "Test Description",
            Price = 123.45m
        };

        // ---------------- READ ----------------

        [Benchmark]
        public List<Product> GetAllProducts_ADO()
        {
            var result = new List<Product>();
            adoConnection.Open();

            using var command = new SqlCommand("SELECT Id, Name, Description, Price FROM Products", adoConnection);
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                result.Add(new Product
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Description = reader.GetString(2),
                    Price = reader.GetDecimal(3)
                });
            }

            adoConnection.Close();
            return result;
        }

        [Benchmark]
        public List<Product> GetAllProducts_Dapper()
        {
            dapperConnection.Open();
            var result = dapperConnection.Query<Product>("SELECT Id, Name, Description, Price FROM Products").ToList();
            dapperConnection.Close();
            return result;
        }

        [Benchmark]
        public List<Product> GetAllProducts_EF()
        {
            return efContext.Products.ToList();
        }

        // ---------------- CREATE ----------------

        [Benchmark]
        public void InsertProduct_ADO()
        {
            adoConnection.Open();
            using var command = new SqlCommand(
                "INSERT INTO Products (Name, Description, Price) VALUES (@Name, @Description, @Price)", adoConnection);
            command.Parameters.AddWithValue("@Name", testProduct.Name);
            command.Parameters.AddWithValue("@Description", testProduct.Description);
            command.Parameters.AddWithValue("@Price", testProduct.Price);
            command.ExecuteNonQuery();
            adoConnection.Close();
        }

        [Benchmark]
        public void InsertProduct_Dapper()
        {
            dapperConnection.Open();
            string sql = "INSERT INTO Products (Name, Description, Price) VALUES (@Name, @Description, @Price)";
            dapperConnection.Execute(sql, testProduct);
            dapperConnection.Close();
        }

        [Benchmark]
        public void InsertProduct_EF()
        {
            efContext.Products.Add(testProduct);
            efContext.SaveChanges();
        }

        // ---------------- UPDATE ----------------

        [Benchmark]
        public void UpdateProduct_ADO()
        {
            adoConnection.Open();
            using var command = new SqlCommand(
                "UPDATE Products SET Price = @Price WHERE Name = @Name", adoConnection);
            command.Parameters.AddWithValue("@Price", testProduct.Price + 1);
            command.Parameters.AddWithValue("@Name", testProduct.Name);
            command.ExecuteNonQuery();
            adoConnection.Close();
        }

        [Benchmark]
        public void UpdateProduct_Dapper()
        {
            dapperConnection.Open();
            string sql = "UPDATE Products SET Price = @Price WHERE Name = @Name";
            dapperConnection.Execute(sql, new { Price = testProduct.Price + 1, Name = testProduct.Name });
            dapperConnection.Close();
        }

        [Benchmark]
        public void UpdateProduct_EF()
        {
            var product = efContext.Products.FirstOrDefault(p => p.Name == testProduct.Name);
            if (product != null)
            {
                product.Price += 1;
                efContext.SaveChanges();
            }
        }

        // ---------------- DELETE ----------------

        [Benchmark]
        public void DeleteProduct_ADO()
        {
            adoConnection.Open();
            using var command = new SqlCommand("DELETE FROM Products WHERE Name = @Name", adoConnection);
            command.Parameters.AddWithValue("@Name", testProduct.Name);
            command.ExecuteNonQuery();
            adoConnection.Close();
        }

        [Benchmark]
        public void DeleteProduct_Dapper()
        {
            dapperConnection.Open();
            string sql = "DELETE FROM Products WHERE Name = @Name";
            dapperConnection.Execute(sql, new { Name = testProduct.Name });
            dapperConnection.Close();
        }

        [Benchmark]
        public void DeleteProduct_EF()
        {
            var product = efContext.Products.FirstOrDefault(p => p.Name == testProduct.Name);
            if (product != null)
            {
                efContext.Products.Remove(product);
                efContext.SaveChanges();
            }
        }
    }
}