using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using NUShop.Data.Dapper.Interfaces;
using NUShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace NUShop.Data.Dapper.Implements
{
    public class CategoryDapperRepository : ICategoryDapperRepository
    {
        private readonly IConfiguration _config;

        public CategoryDapperRepository(IConfiguration config)
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

        public Category Add(Category category)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                long id = conn.Insert(category);
                return GetById(Convert.ToInt32(id));
            }
        }

        public bool Delete(int id)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                var category = GetById(id);
                return conn.Delete(category);
            }
        }

        public IEnumerable<Category> GetAll()
        {
            using (IDbConnection conn = Connection)
            {
                string query = "SELECT * FROM Categories";
                conn.Open();
                var result = conn.Query<Category>(query);
                return result;
            }
        }

        public IEnumerable<Category> GetAll(string keyword)
        {
            using (IDbConnection conn = Connection)
            {
                string query = "SELECT * FROM Categories WHERE Name like %@KEYWORD%";
                conn.Open();
                var result = conn.Query<Category>(query, new { KEYWORD = keyword });
                return result;
            }
        }

        public Category GetById(int id)
        {
            using (IDbConnection conn = Connection)
            {
                string query = "SELECT * FROM Categories WHERE Id = @ID";
                conn.Open();
                var result = conn.Query<Category>(query, new { ID = id });
                return result.FirstOrDefault();
            }
        }

        public Category Update(Category category)
        {
            using (IDbConnection conn = Connection)
            {
                conn.Open();
                bool isUpdated = conn.Update(category);
                if (!isUpdated)
                {
                    return new Category();
                }
                return GetById(category.Id);
            }
        }
    }
}