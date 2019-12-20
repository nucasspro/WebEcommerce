using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NUShop.Data.EF;
using NUShop.Data.Entities;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.WebAPI.Controllers.ProductControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStoreProcedureController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public ProductStoreProcedureController(AppDbContext context, IMapper mapper, IConfiguration configuration)
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
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                try
                {
                    string query = "sp_GetProductByName";
                    var command = new SqlCommand(query, connection)
                    {
                        CommandType = System.Data.CommandType.StoredProcedure
                    };
                    command.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
                    command.Parameters["@name"].Value = name;
                    connection.Open();

                    var reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var product = new Product
                            {
                                Id = Convert.ToInt32(reader[0]),
                                Name = reader[1].ToString(),
                                CategoryId = Convert.ToInt32(reader[2]),
                                Image = reader[3].ToString(),
                                Price = Convert.ToInt32(reader[4]),
                                PromotionPrice = Convert.ToInt32(reader[5]),
                                OriginalPrice = Convert.ToInt32(reader[6]),
                                Description = reader[7].ToString(),
                                Content = reader[8].ToString(),
                                Unit = reader[13].ToString(),
                                SeoPageTitle = reader[14].ToString(),
                                SeoAlias = reader[15].ToString(),
                                SeoKeywords = reader[16].ToString(),
                                SeoDescription = reader[17].ToString(),
                                DateCreated = reader[18].ToString(),
                                DateModified = reader[19].ToString(),
                                Status = (Data.Enums.Status)Convert.ToInt32(reader[20])
                            };
                            return _mapper.Map<ProductViewModel>(product);
                        }
                    }
                    reader.Close();
                    return NotFound();
                }
                catch (Exception ex)
                {
                    return NotFound(ex.Message);
                }
            }
        }

        //// PUT: api/ProductsSqlRaw/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }

        //        throw;
        //    }

        //    return NoContent();
        //}

        //// POST: api/ProductsSqlRaw
        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        //}

        //// DELETE: api/ProductsSqlRaw/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Product>> DeleteProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return product;
        //}

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}