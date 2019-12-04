using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.Utilities.DTOs;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NUShop.Service.Implements
{
    public class CategoryService : ICategoryService
    {
        #region Injections

        private readonly IRepository<Category, int> _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category, int> categoryRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Injections

        #region Implements

        public CategoryViewModel Add(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Add(category);
            _unitOfWork.Commit();
            return categoryViewModel;
        }

        public void Delete(int id)
        {
            _categoryRepository.Remove(id);
            _unitOfWork.Commit();
        }

        public List<CategoryViewModel> GetAll()
        {
            var categories = _categoryRepository.GetAll().OrderBy(x => x.ParentId);
            var categoriesViewModel = _mapper.Map<List<CategoryViewModel>>(categories);
            return categoriesViewModel;
        }

        public List<CategoryViewModel> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                var categories = _categoryRepository
                    .GetAll(x => x.Name.Contains(keyword) || x.Description.Contains(keyword)).OrderBy(x => x.ParentId);
                var categoriesViewModel = _mapper.Map<List<CategoryViewModel>>(categories);
                return categoriesViewModel;
            }
            else
            {
                var categories = _categoryRepository.GetAll().OrderBy(x => x.ParentId);
                var categoriesViewModel = _mapper.Map<List<CategoryViewModel>>(categories);
                return categoriesViewModel;
            }
        }

        public List<CategoryViewModel> GetAllByParentId(int parentId)
        {
            var categories = _categoryRepository.GetAll(x => x.Status == Status.Active);
            var categoriesViewModel = _mapper.Map<List<CategoryViewModel>>(categories);
            return categoriesViewModel;
        }

        public PagedResult<CategoryViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _categoryRepository.GetAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.Id == categoryId.Value || x.ParentId == categoryId.Value);
            }

            var totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);

            var data = _mapper.Map<List<CategoryViewModel>>(query);

            var paginationSet = new PagedResult<CategoryViewModel>()
            {
                Results = data,
                CurrentPage = page,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public CategoryViewModel GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return categoryViewModel;
        }

        public List<CategoryViewModel> GetHomeCategories(int top)
        {
            var query = _categoryRepository.GetAll(x => x.HomeFlag == true, c => c.Products).OrderBy(x => x.HomeOrder).Take(top);
            var queryViewModel = _mapper.Map<List<CategoryViewModel>>(query);

            var categories = queryViewModel.ToList();
            foreach (var category in categories)
            {
                //category.Products = _productRepository
                //    .FindAll(x => x.HotFlag == true && x.CategoryId == category.Id)
                //    .OrderByDescending(x => x.DateCreated)
                //    .Take(5)
                //    .ProjectTo<ProductViewModel>().ToList();
            }
            return categories;
        }

        public void ReOrder(int sourceId, int targetId)
        {
            var source = _categoryRepository.GetById(sourceId);
            var target = _categoryRepository.GetById(targetId);
            var tempOrder = source.SortOrder;
            source.SortOrder = target.SortOrder;
            target.SortOrder = tempOrder;

            _categoryRepository.Update(source);
            _categoryRepository.Update(target);
            _unitOfWork.Commit();
        }

        public void Update(CategoryViewModel categoryViewModel)
        {
            var oldCategory = _mapper.Map<Category>(GetById(categoryViewModel.Id));

            var category = _mapper.Map<Category>(categoryViewModel);
            category.DateCreated = oldCategory.DateCreated;
            category.DateModified = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);

            _categoryRepository.Update(category);
            _unitOfWork.Commit();
        }

        public void UpdateParentId(int sourceId, int targetId, Dictionary<int, int> items)
        {
            var sourceCategory = _categoryRepository.GetById(sourceId);
            sourceCategory.ParentId = targetId;
            _categoryRepository.Update(sourceCategory);

            //Get all sibling
            var sibling = _categoryRepository.GetAll(x => items.ContainsKey(x.Id));
            foreach (var child in sibling)
            {
                child.SortOrder = items[child.Id];
                _categoryRepository.Update(child);
            }
            _unitOfWork.Commit();
        }

        #endregion Implements
    }
}