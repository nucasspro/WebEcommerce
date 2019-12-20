using Dapper;
using Microsoft.Extensions.Configuration;
using NUShop.Data.Dapper.Interfaces;
using NUShop.Data.Entities;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NUShop.Data.Dapper.Implements
{
    public class ProductDapperRepository : IProductDapperRepository
    {
        private readonly IConfiguration _config;

        public ProductDapperRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string query = "SELECT * FROM PRODUCTS";
                conn.Open();
                var result = conn.Query<Product>(query);
                return result;
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string query = "SELECT * FROM PRODUCTS WHERE Id = @ID";
                conn.Open();
                var result = conn.Query<Product>(query, new { ID = id });
                return result.FirstOrDefault();
            }
        }

        public Product GetByName(string name)
        {
            using (IDbConnection conn = Connection)
            {
                string query = "sp_GetProductByName";
                conn.Open();

                var queryParameters = new DynamicParameters();
                queryParameters.Add("@name", name);

                var result = conn.Query<Product>(query, queryParameters, commandType: CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
    }
}