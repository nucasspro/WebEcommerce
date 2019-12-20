using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUShop.Data.EF;
using NUShop.Data.Entities;
using NUShop.ViewModel.ViewModels;

namespace NUShop.WebAPI.Controllers.ProductControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsSqlRawController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProductsSqlRawController(AppDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }

        // GET: api/ProductsSqlRaw
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        // GET: api/ProductsSqlRaw/5
        [HttpGet("GetByName")]
        public ActionResult<ProductViewModel> GetProduct([FromQuery]string name)
        {
            //var product = _context.Products.FromSql("select * from Products where name = '" + name + "'").FirstOrDefault();
            var product = new Product();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    var command = new SqlCommand("select top(1) * from Products where name = '" + name + "'", connection);
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        product.Id = Convert.ToInt32(reader[0]);
                        product.Name = reader[1].ToString();
                        product.CategoryId = Convert.ToInt32(reader[2]);
                        product.Image = reader[3].ToString();
                        product.Price = Convert.ToInt32(reader[4]);
                        product.PromotionPrice = Convert.ToInt32(reader[5]);
                        product.OriginalPrice = Convert.ToInt32(reader[6]);
                        product.Description = reader[7].ToString();
                        product.Content = reader[8].ToString();
                        product.Unit = reader[13].ToString();
                        product.SeoPageTitle = reader[14].ToString();
                        product.SeoAlias = reader[15].ToString();
                        product.SeoKeywords = reader[16].ToString();
                        product.SeoDescription = reader[17].ToString();
                        product.DateCreated = reader[18].ToString();
                        product.DateModified = reader[19].ToString();
                        product.Status = (Data.Enums.Status)Convert.ToInt32(reader[20]);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }

            return _mapper.Map<ProductViewModel>(product);
        }

        // PUT: api/ProductsSqlRaw/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // POST: api/ProductsSqlRaw
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/ProductsSqlRaw/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
