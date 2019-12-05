using AutoMapper;
using NUShop.Data.Dapper.Interfaces;
using NUShop.Service.Dapper.Interfaces;
using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;

namespace NUShop.Service.Dapper.Implements
{
    public class ProductDapperService : IProductDapperService
    {
        #region Injections

        //private readonly IRepository<Product, int> _productRepository;
        //private readonly IRepository<Tag, string> _tagRepository;
        //private readonly IRepository<ProductTag, int> _productTagRepository;
        //private readonly IRepository<ProductQuantity, int> _productQuantityRepository;
        //private readonly IRepository<ProductImage, int> _productImageRepository;
        //private readonly IRepository<WholePrice, int> _wholePriceRepository;
        private readonly IProductDapperRepository _productRepository;

        private readonly IMapper _mapper;
        //private readonly IUnitOfWork _unitOfWork;

        //public ProductService(
        //    IRepository<Product, int> productRepository,
        //    IRepository<Tag, string> tagRepository,
        //    IRepository<ProductQuantity, int> productQuantityRepository,
        //    IRepository<ProductImage, int> productImageRepository,
        //    IRepository<WholePrice, int> wholePriceRepository,
        //    IRepository<ProductTag, int> productTagRepository,
        //    IUnitOfWork unitOfWork, IMapper mapper)
        //{
        //    _productRepository = productRepository;
        //    _tagRepository = tagRepository;
        //    _productQuantityRepository = productQuantityRepository;
        //    _productTagRepository = productTagRepository;
        //    _wholePriceRepository = wholePriceRepository;
        //    _productImageRepository = productImageRepository;
        //    _mapper = mapper;
        //    _unitOfWork = unitOfWork;
        //}
        public ProductDapperService(IProductDapperRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        #endregion Injections

        public List<ProductViewModel> GetAll()
        {
            var products = _productRepository.GetAll();
            var productsViewModel = _mapper.Map<List<ProductViewModel>>(products);
            return productsViewModel;
        }

        public ProductViewModel GetById(int id)
        {
            var product = _productRepository.GetById(id);
            var productViewModel = _mapper.Map<ProductViewModel>(product);
            return productViewModel;
        }
    }
}