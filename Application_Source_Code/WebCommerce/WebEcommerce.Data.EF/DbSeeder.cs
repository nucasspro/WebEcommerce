using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data.Entities;
using WebEcommerce.Model.Enums;
using WebEcommerce.Utility.Helpers;

namespace WebEcommerce.Data.EF
{
    public class DbSeeder
    {
        private readonly AppDbContext _context;

        public DbSeeder(AppDbContext context)
        {
            _context = context;
        }

        public async Task Seed()
        {
            var datetime = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);

            if (_context.Colors.Count() == 0)
            {
                List<Color> listColor = new List<Color>()
                {
                    new Color() {Name="Black"   , Code="#000000" },
                    new Color() {Name="White"   , Code="#FFFFFF"},
                    new Color() {Name="Red"     , Code="#ff0000" },
                    new Color() {Name="Blue"    , Code="#1000ff" },
                };
                _context.Colors.AddRange(listColor);
            }
            if (_context.Sizes.Count() == 0)
            {
                List<Size> listSize = new List<Size>()
                {
                    new Size() { Name="XXL" },
                    new Size() { Name="XL"  },
                    new Size() { Name="L"   },
                    new Size() { Name="M"   },
                    new Size() { Name="S"   },
                    new Size() { Name="XS"  }
                };
                _context.Sizes.AddRange(listSize);
            }
            if (_context.Categories.Count() == 0)
            {
                List<Category> listProductCategory = new List<Category>()
                {
                    new Category()
                    {
                        Name ="Men shirt",
                        ParentId = null,
                        Status =Status.Active,
                        SortOrder =1,
                        DateCreated = datetime,
                        DateModified = datetime,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 01",DateCreated = datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 02",DateCreated = datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 03",DateCreated = datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 04",DateCreated = datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 05",DateCreated = datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    },
                    new Category() {
                        Name = "Women shirt",
                        ParentId = null,
                        Status =Status.Active,
                        SortOrder = 2,
                        DateCreated = datetime,
                        DateModified = datetime,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 06",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 07",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 08",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 09",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 10",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    },
                    new Category()
                    {
                        Name ="Men shoes",
                        ParentId = null,
                        Status =Status.Active ,
                        SortOrder =3,
                        DateCreated = datetime,
                        DateModified = datetime,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 11",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 12",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 13",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 14",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 15",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    },
                    new Category()
                    {
                        Name ="Woment shoes",
                        ParentId = null,
                        Status =Status.Active,
                        SortOrder =4,
                        DateCreated = datetime,
                        DateModified = datetime,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 16",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 17",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 18",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 19",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 20",DateCreated=datetime, DateModified = datetime, Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    }
                };
                _context.Categories.AddRange(listProductCategory);
            }

            await _context.SaveChangesAsync();
        }
    }
}