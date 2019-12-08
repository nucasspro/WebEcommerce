using AutoMapper;
using NUShop.Data.Dapper.Interfaces;
using NUShop.Data.Entities;
using NUShop.Service.Dapper.Interfaces;
using NUShop.Utilities.DTOs;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUShop.Service.Dapper.Implements
{
    public class CategoryDapperService : ICategoryDapperService
    {
        #region Injections

        private readonly ICategoryDapperRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryDapperService(ICategoryDapperRepository categoryRepository,/* IUnitOfWork unitOfWork,*/ IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            //_unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        #endregion Injections

        #region Implements

        public CategoryViewModel Add(CategoryViewModel categoryViewModel)
        {
            var category = _mapper.Map<Category>(categoryViewModel);
            _categoryRepository.Add(category);
            //_unitOfWork.Commit();
            return categoryViewModel;
        }

        public bool Delete(int id)
        {
            var isDeleted = _categoryRepository.Delete(id);
            return isDeleted;
            //_unitOfWork.Commit();
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
                var categories = _categoryRepository.GetAll(keyword).OrderBy(x => x.Id);
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



        //public PagedResult<CategoryViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        //{
        //    var query = _categoryRepository.GetAll(x => x.Status == Status.Active);
        //    if (!string.IsNullOrEmpty(keyword))
        //    {
        //        query = query.Where(x => x.Name.Contains(keyword));
        //    }

        //    if (categoryId.HasValue)
        //    {
        //        query = query.Where(x => x.Id == categoryId.Value || x.ParentId == categoryId.Value);
        //    }

        //    var totalRow = query.Count();

        //    query = query.OrderByDescending(x => x.DateCreated).Skip((page - 1) * pageSize).Take(pageSize);

        //    var data = _mapper.Map<List<CategoryViewModel>>(query);

        //    var paginationSet = new PagedResult<CategoryViewModel>()
        //    {
        //        Results = data,
        //        CurrentPage = page,
        //        RowCount = totalRow,
        //        PageSize = pageSize
        //    };
        //    return paginationSet;
        //}

        public CategoryViewModel GetById(int id)
        {
            var category = _categoryRepository.GetById(id);
            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return categoryViewModel;
        }

      

        public CategoryViewModel Update(CategoryViewModel categoryViewModel)
        {
            var oldCategory = _mapper.Map<Category>(GetById(categoryViewModel.Id));

            var category = _mapper.Map<Category>(categoryViewModel);
            category.DateCreated = oldCategory.DateCreated;
            category.DateModified = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);

            return _mapper.Map<CategoryViewModel>(_categoryRepository.Update(category));
            //_unitOfWork.Commit();
        }

      

        #endregion Implements
    }
}
