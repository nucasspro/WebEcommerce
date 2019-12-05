using NUShop.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.Data.Dapper.Interfaces
{
    public interface IProductDapperRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
    }
}
