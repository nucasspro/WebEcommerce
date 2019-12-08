using NUShop.Data.Entities;
using System.Collections.Generic;

namespace NUShop.Data.Dapper.Interfaces
{
    public interface ICategoryDapperRepository
    {
        IEnumerable<Category> GetAll();

        IEnumerable<Category> GetAll(string keyword);

        Category GetById(int id);

        Category Add(Category category);

        Category Update(Category category);

        bool Delete(int id);
    }
}