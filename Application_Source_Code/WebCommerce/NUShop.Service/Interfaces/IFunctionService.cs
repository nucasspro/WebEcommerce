using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NUShop.Service.EF.Interfaces
{
    public interface IFunctionService
    {
        Task<FunctionViewModel> Add(FunctionViewModel functionViewModel);

        Task<FunctionViewModel> Update(FunctionViewModel functionViewModel);

        Task Delete(string id);

        Task<List<FunctionViewModel>> GetAll(string filter);

        List<FunctionViewModel> GetAllByParentId(string parentId);

        FunctionViewModel GetById(string id);

        Task UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        Task ReOrder(string sourceId, string targetId);
    }
}