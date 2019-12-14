using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Dapper.Interfaces;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDapperController : ControllerBase
    {
        #region Injections

        private readonly IProductDapperService _productService;
        //private readonly ICategoryService _categoryService;
        private readonly ILogger<ProductDapperController> _logger;

        public ProductDapperController(IProductDapperService productService, /*ICategoryService categoryService,*/ ILogger<ProductDapperController> logger)
        {
            _productService = productService;
            //_categoryService = categoryService;
            _logger = logger;
        }

        #endregion Injections

        #region REST

        #region GET: api/ProductDapper

        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            return new OkObjectResult(products);
        }

        #endregion GET: api/ProductDapper

        //#region GET: api/ProductDapper/GetAllPaging?

        //[HttpGet("GetAllPaging")]
        //public IActionResult GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        //{
        //    if (categoryId <= 0)
        //    {
        //        categoryId = 1;
        //    }
        //    var products = _productService.GetAllPaging(categoryId, keyword, page, pageSize);
        //    return new OkObjectResult(products);
        //}

        //#endregion GET: api/ProductDapper/GetAllPaging?

        #region GET: api/ProductDapper/1

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _productService.GetById(id);
            return new OkObjectResult(product);
        }

        #endregion GET: api/ProductDapper/1

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

        //[HttpPost]
        //public IActionResult SaveEntity(ProductViewModel productViewModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        return new BadRequestObjectResult(allErrors);
        //    }

        //    productViewModel.SeoAlias = TextHelper.ToUnsignString(productViewModel.Name);
        //    if (productViewModel.Id == 0)
        //    {
        //        _productService.Add(productViewModel);
        //    }
        //    else
        //    {
        //        _productService.Update(productViewModel);
        //    }
        //    return new OkObjectResult(productViewModel);
        //}

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

        #region DELETE: api/ProductDapper/1

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

        #endregion DELETE: api/ProductDapper/1

        #endregion REST
    }
}