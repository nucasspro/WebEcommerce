using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.ViewModel.ViewModels;
using NUShop.Utilities.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        #region Injections

        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        #endregion Injections

        #region REST

        #region GET: api/Category

        [HttpGet]
        public IActionResult GetAll()
        {
            var model = _categoryService.GetAll();
            return new OkObjectResult(model);
        }

        #endregion GET: api/Category

        #region GET: api/Category/1

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var model = _categoryService.GetById(id);

            return new ObjectResult(model);
        }

        #endregion GET: api/Category/1

        [HttpPut]
        public IActionResult UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            if (sourceId == targetId)
            {
                return new BadRequestResult();
            }

            _categoryService.UpdateParentId(sourceId, targetId, items);
            return new OkResult();
        }

        #region POST: api/Category

        [HttpPost]
        public IActionResult SaveEntity(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                var allErrors = ModelState.Values.SelectMany(v => v.Errors);
                return new BadRequestObjectResult(allErrors);
            }

            categoryViewModel.SeoAlias = TextHelper.ToUnsignString(categoryViewModel.Name);
            if (categoryViewModel.Id == 0)
            {
                _categoryService.Add(categoryViewModel);
            }
            else
            {
                _categoryService.Update(categoryViewModel);
            }
            return new OkObjectResult(categoryViewModel);
        }

        #endregion POST: api/Category

        [HttpPost("ReOrder/")]
        public IActionResult ReOrder(int sourceId, int targetId)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestObjectResult(ModelState);
            }

            if (sourceId == targetId)
            {
                return new BadRequestResult();
            }

            _categoryService.ReOrder(sourceId, targetId);
            return new OkResult();
        }

        #region DELETE: api/Category/1

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }

            _categoryService.Delete(id);
            return new OkObjectResult(id);
        }

        #endregion DELETE: api/Category/1

        #endregion REST
    }
}