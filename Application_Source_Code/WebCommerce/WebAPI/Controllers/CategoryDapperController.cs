using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Dapper.Interfaces;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryDapperController : ControllerBase
    {
        #region Injections

        private readonly ICategoryDapperService _categoryService;
        private readonly ILogger<CategoryDapperController> _logger;

        public CategoryDapperController(ICategoryDapperService categoryService, ILogger<CategoryDapperController> logger)
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


        #region DELETE: api/Category/1

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return new BadRequestResult();
            }

            var isDeleted = _categoryService.Delete(id);
            if (!isDeleted)
            {
                return new BadRequestObjectResult("Error!");
            }
            return new OkObjectResult(id);
        }

        #endregion DELETE: api/Category/1

        #endregion REST
    }
}