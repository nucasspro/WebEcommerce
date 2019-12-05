using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.ViewModel.ViewModels;
using NUShop.Utilities.Helpers;
using System.Linq;
using NUShop.Service.EF.Interfaces;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Injections

        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService productService, ICategoryService categoryService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _categoryService = categoryService;
            _logger = logger;
        }

        #endregion Injections

        #region REST

        #region GET: api/Product

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return new OkObjectResult(products);
        }

        #endregion GET: api/Product

        #region GET: api/Product/GetAllPaging?

        [HttpGet("GetAllPaging")]
        public IActionResult GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            if (categoryId<=0)
            {
                categoryId = 1;
            }
            var products = _productService.GetAllPaging(categoryId, keyword, page, pageSize);
            return new OkObjectResult(products);
        }

        #endregion GET: api/Product/GetAllPaging?

        #region GET: api/Product/1

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return new OkObjectResult(product);
        }

        #endregion GET: api/Product/1

        //[HttpGet]
        //public IActionResult GetQuantities(int productId)
        //{
        //    var quantities = _productService.GetQuantities(productId);
        //    return new OkObjectResult(quantities);
        //}

        //[HttpGet]
        //public IActionResult GetImages(int productId)
        //{
        //    var images = _productService.GetImages(productId);
        //    return new OkObjectResult(images);
        //}

        //[HttpGet]
        //public IActionResult GetWholePrices(int productId)
        //{
        //    var wholePrices = _productService.GetWholePrices(productId);
        //    return new OkObjectResult(wholePrices);
        //}

        [HttpPost]
        public IActionResult SaveEntity(ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }

            productViewModel.SeoAlias = TextHelper.ToUnsignString(productViewModel.Name);
            if (productViewModel.Id == 0)
            {
                _productService.Add(productViewModel);
            }
            else
            {
                _productService.Update(productViewModel);
            }
            return new OkObjectResult(productViewModel);
        }

        //[HttpPost]
        //public IActionResult SaveQuantities(int productId, List<ProductQuantityViewModel> quantities)
        //{
        //    _productService.AddQuantity(productId, quantities);
        //    return new OkObjectResult(quantities);
        //}

        //[HttpPost]
        //public IActionResult SaveImages(int productId, string[] images)
        //{
        //    _productService.AddImages(productId, images);
        //    return new OkObjectResult(images);
        //}

        //[HttpPost]
        //public IActionResult SaveWholePrice(int productId, List<WholePriceViewModel> wholePrices)
        //{
        //    _productService.AddWholePrice(productId, wholePrices);
        //    return new OkObjectResult(wholePrices);
        //}

        #region DELETE: api/Product/1

        //[HttpDelete]
        //public IActionResult Delete(int id)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new BadRequestObjectResult(ModelState);
        //    }

        //    _productService.Delete(id);

        //    return new OkObjectResult(id);
        //}

        #endregion DELETE: api/Product/1

        #endregion REST
    }
}