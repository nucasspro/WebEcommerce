using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebEcommerce.Data.Entities;
using WebEcommerce.Infrastructure.Interfaces;
using WebEcommerce.Model.Enums;
using WebEcommerce.Service.Interfaces;
using WebEcommerce.Utility.Helpers;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Implements
{
    public class ProductService : IProductService
    {
        #region Injections

        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<ProductQuantity, int> _productQuantityRepository;
        private readonly IRepository<ProductImage, int> _productImageRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IRepository<Product, int> productRepository,
            IRepository<ProductQuantity, int> productQuantityRepository,
            IRepository<ProductImage, int> productImageRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _productQuantityRepository = productQuantityRepository;
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion Injections

        #region C

        public ProductViewModel Add(ProductViewModel productViewModel)
        {
            var product = _mapper.Map<Product>(productViewModel);
            var datimeNow = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);
            product.DateCreated = datimeNow;
            product.DateModified = datimeNow;
            _productRepository.Add(product);
            _unitOfWork.Commit();
            return productViewModel;
        }

        public void AddQuantity(int productId, List<ProductQuantityViewModel> quantities)
        {
            _productQuantityRepository.RemoveMultiple(_productQuantityRepository.GetAll(x => x.ProductId == productId).ToList());
            foreach (var quantity in quantities)
            {
                _productQuantityRepository.Add(new ProductQuantity()
                {
                    ProductId = productId,
                    ColorId = quantity.ColorId,
                    SizeId = quantity.SizeId,
                    Quantity = quantity.Quantity
                });
            }
            _unitOfWork.Commit();
        }

        public void AddImages(int productId, string[] images)
        {
            _productImageRepository.RemoveMultiple(_productImageRepository.GetAll(x => x.ProductId == productId).ToList());
            foreach (var image in images)
            {
                _productImageRepository.Add(new ProductImage()
                {
                    Path = image,
                    ProductId = productId,
                    Caption = string.Empty
                });
            }
            _unitOfWork.Commit();
        }


        #endregion C

        #region R

        public List<ProductViewModel> GetAll()
        {
            var products = _productRepository.GetAll();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int pageIndex, int pageSize)
        {
            var query = _productRepository.GetAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(x => x.Name.Contains(keyword));
            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId.Value);

            var totalRow = query.Count();

            query = query.OrderByDescending(x => x.DateCreated)
                .Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var data = _mapper.Map<List<ProductViewModel>>(query);

            var paginationSet = new PagedResult<ProductViewModel>()
            {
                Results = data,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public ProductViewModel GetById(int id)
        {
            var product = _productRepository.GetById(id);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }

        public List<ProductQuantityViewModel> GetQuantities(int productId)
        {
            var productQuantities = _productQuantityRepository.GetAll(x => x.ProductId == productId);
            var productQuantitiesViewModel = _mapper.Map<List<ProductQuantityViewModel>>(productQuantities);
            return productQuantitiesViewModel;
        }

        public List<ProductImageViewModel> GetImages(int productId)
        {
            var productImages = _productImageRepository.GetAll(x => x.ProductId == productId);
            var productImagesViewModel = _mapper.Map<List<ProductImageViewModel>>(productImages);
            return productImagesViewModel;
        }


        public List<ProductViewModel> GetLastest(int top)
        {
            var products = _productRepository.GetAll(x => x.Status == Status.Active)
                .OrderByDescending(x => x.DateCreated)
                .Take(top);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public List<ProductViewModel> GetHotProduct(int top)
        {
            var products = _productRepository
                .GetAll(x => x.Status == Status.Active && x.HotFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(top);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public List<ProductViewModel> GetRelatedProducts(int id, int top)
        {
            var product = _productRepository.GetById(id);
            var relatedProducts = _productRepository
                .GetAll(x => x.Status == Status.Active && x.Id != id && x.CategoryId == product.CategoryId)
                .OrderByDescending(x => x.DateCreated)
                .Take(top);
            var relatedProductsViewModel = _mapper.Map<List<ProductViewModel>>(relatedProducts);
            return relatedProductsViewModel;
        }

        public List<ProductViewModel> GetUpSellProducts(int top)
        {
            var products = _productRepository
                            .GetAll(x => x.PromotionPrice != null)
                            .OrderByDescending(x => x.DateModified).Take(top);
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }


        #endregion R

        #region U

        public void Update(ProductViewModel productViewModel)
        {
            var oldProduct = _mapper.Map<Product>(GetById(productViewModel.Id));

            var product = _mapper.Map<Product>(productViewModel);
            product.DateCreated = oldProduct.DateCreated;
            product.DateModified = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);

            _productRepository.Update(product);
            _unitOfWork.Commit();
        }

        #endregion U

        #region D

        public void Delete(int id)
        {
            _productRepository.Remove(id);
            _unitOfWork.Commit();
        }

        #endregion D

        public bool CheckAvailability(int productId, int size, int color)
        {
            var quantity = _productQuantityRepository.GetSingle(x => x.ColorId == color && x.SizeId == size && x.ProductId == productId);
            if (quantity == null)
                return false;
            return quantity.Quantity > 0;
        }
    }
}