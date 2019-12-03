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
                        Status =Status.Active,
                        SortOrder =1,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 01", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 02", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 03", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 04", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 05", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    },
                    new Category() {
                        Name = "Women shirt",
                        Status =Status.Active,
                        SortOrder = 2,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 06", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 07", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 08", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 09", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 10", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    },
                    new Category()
                    {
                        Name ="Men shoes",
                        Status =Status.Active ,
                        SortOrder =3,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 11", Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 12", Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 13", Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 14", Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 15", Image="/client-side/images/products/product-1.jpg",Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    },
                    new Category()
                    {
                        Name ="Woment shoes",
                        Status =Status.Active,
                        SortOrder =4,
                        Products = new List<Product>()
                        {
                            new Product(){Name = "Product 16", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 17", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 18", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 19", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                            new Product(){Name = "Product 20", Image="/client-side/images/products/product-1.jpg", Price = 1000,Status = Status.Active,OriginalPrice = 1000},
                        }
                    }
                };
                _context.Categories.AddRange(listProductCategory);
            }

            await _context.SaveChangesAsync();
        }
    }
}