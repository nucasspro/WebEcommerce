using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.Service.Implements
{
    public class FunctionService : IFunctionService
    {
        #region Injections

        private readonly IRepository<Function, string> _functionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FunctionService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Function, string> functionRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _functionRepository = functionRepository;
        }

        #endregion Injections

        #region Implements

        public async Task<FunctionViewModel> Add(FunctionViewModel functionViewModel)
        {
            var function = _mapper.Map<Function>(functionViewModel);
            _functionRepository.Add(function);
            await _unitOfWork.CommitAsync();
            return functionViewModel;
        }

        public async Task Delete(string id)
        {
            _functionRepository.Remove(id);
            await _unitOfWork.CommitAsync();
        }

        public async Task<List<FunctionViewModel>> GetAll(string filter)
        {
            var functions = _functionRepository.GetAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(filter))
            {
                functions = functions.Where(x => x.Name.Contains(filter));
            }
            var functionsOrderBy = await functions.OrderBy(x => x.ParentId).ToListAsync();
            var functionsViewModel = _mapper.Map<List<FunctionViewModel>>(functionsOrderBy);
            return functionsViewModel;
        }

        public List<FunctionViewModel> GetAllByParentId(string parentId)
        {
            var functions = _functionRepository.GetAll(x => x.ParentId == parentId && x.Status == Status.Active);
            var functionsViewModel = _mapper.Map<List<FunctionViewModel>>(functions);
            return functionsViewModel;
        }

        public FunctionViewModel GetById(string id)
        {
            var function = _functionRepository.GetById(id);
            var functionViewModel = _mapper.Map<FunctionViewModel>(function);
            return functionViewModel;
        }

        public async Task ReOrder(string sourceId, string targetId)
        {
            var source = _functionRepository.GetById(sourceId);
            var target = _functionRepository.GetById(targetId);
            int tempOrder = source.SortOrder;

            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _functionRepository.Update(source);
            _functionRepository.Update(target);
            await _unitOfWork.CommitAsync();
        }

        public async Task<FunctionViewModel> Update(FunctionViewModel functionViewModel)
        {
            var function = _mapper.Map<Function>(functionViewModel);
            _functionRepository.Update(function);
            await _unitOfWork.CommitAsync();
            return functionViewModel;
        }

        public async Task UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items)
        {
            var category = _functionRepository.GetById(sourceId);
            category.ParentId = targetId;
            _functionRepository.Update(category);

            var sibling = _functionRepository.GetAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _functionRepository.Update(child);
            }
            await _unitOfWork.CommitAsync();
        }

        #endregion Implements
    }
}