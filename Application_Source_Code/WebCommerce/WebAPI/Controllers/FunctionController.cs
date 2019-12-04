using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUShop.Service.Interfaces;
using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FunctionController : ControllerBase
    {
        #region Injections

        private readonly IFunctionService _functionService;
        private readonly ILogger<FunctionController> _logger;

        public FunctionController(IFunctionService functionService, ILogger<FunctionController> logger)
        {
            _functionService = functionService;
            _logger = logger;
        }

        #endregion Injections

        //[HttpGet]
        //public IActionResult GetAllFillter(string filter)
        //{
        //    var model = _functionService.GetAll(filter);
        //    return new ObjectResult(model);
        //}

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var model = await _functionService.GetAll(string.Empty);
            var rootFunctions = model.Where(c => c.ParentId == null);
            var items = new List<FunctionViewModel>();
            foreach (var function in rootFunctions)
            {
                //add the parent category to the item list
                items.Add(function);
                //now get all its children (separate Category in case you need recursion)
                GetByParentId(model.ToList(), function, items);
            }
            return new ObjectResult(items);
        }

        //[HttpGet]
        //public IActionResult GetById(string id)
        //{
        //    var model = _functionService.GetAll(id);

        //    return new ObjectResult(model);
        //}

        //[HttpPost]
        //public IActionResult SaveEntity(FunctionViewModel functionVm)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        var allErrors = ModelState.Values.SelectMany(v => v.Errors);
        //        return new BadRequestObjectResult(allErrors);
        //    }

        //    if (string.IsNullOrWhiteSpace(functionVm.Id))
        //    {
        //        _functionService.Add(functionVm);
        //    }
        //    else
        //    {
        //        _functionService.Update(functionVm);
        //    }
        //    return new OkObjectResult(functionVm);
        //}

        //[HttpPost]
        //public IActionResult UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new BadRequestObjectResult(ModelState);
        //    }

        //    if (sourceId == targetId)
        //    {
        //        return new BadRequestResult();
        //    }

        //    _functionService.UpdateParentId(sourceId, targetId, items);
        //    return new OkResult();
        //}

        //[HttpPost]
        //public IActionResult ReOrder(string sourceId, string targetId)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return new BadRequestObjectResult(ModelState);
        //    }

        //    if (sourceId == targetId)
        //    {
        //        return new BadRequestResult();
        //    }

        //    _functionService.ReOrder(sourceId, targetId);
        //    return new OkObjectResult(sourceId);
        //}

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (!ModelState.IsValid)
            {
                return new BadRequestResult();
            }

            _functionService.Delete(id);
            return new OkObjectResult(id);
        }

        #region Private Functions

        private void GetByParentId(IEnumerable<FunctionViewModel> allFunctions, FunctionViewModel parent, IList<FunctionViewModel> items)
        {
            var functionsEntities = allFunctions as FunctionViewModel[] ?? allFunctions.ToArray();
            var subFunctions = functionsEntities.Where(c => c.ParentId == parent.Id);
            foreach (var cat in subFunctions)
            {
                //add this category
                items.Add(cat);
                //recursive call in case your have a hierarchy more than 1 level deep
                GetByParentId(functionsEntities, cat, items);
            }
        }

        #endregion Private Functions
    }
}