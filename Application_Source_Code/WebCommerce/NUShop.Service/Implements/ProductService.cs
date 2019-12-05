using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Data.Enums;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.EF.Interfaces;
using NUShop.Utilities.Constants;
using NUShop.Utilities.DTOs;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.Service.EF.Implements
{
    public class ProductService : IProductService
    {
        #region Injections

        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<ProductTag, int> _productTagRepository;
        private readonly IRepository<ProductQuantity, int> _productQuantityRepository;
        private readonly IRepository<ProductImage, int> _productImageRepository;
        private readonly IRepository<WholePrice, int> _wholePriceRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(
            IRepository<Product, int> productRepository,
            IRepository<Tag, string> tagRepository,
            IRepository<ProductQuantity, int> productQuantityRepository,
            IRepository<ProductImage, int> productImageRepository,
            IRepository<WholePrice, int> wholePriceRepository,
            IRepository<ProductTag, int> productTagRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _tagRepository = tagRepository;
            _productQuantityRepository = productQuantityRepository;
            _productTagRepository = productTagRepository;
            _wholePriceRepository = wholePriceRepository;
            _productImageRepository = productImageRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        #endregion Injections

        #region C

        public ProductViewModel Add(ProductViewModel productViewModel)
        {
            var productTags = new List<ProductTag>();
            if (string.IsNullOrEmpty(productViewModel.Tags))
                return productViewModel;

            var tags = productViewModel.Tags.Split(',');
            foreach (var t in tags)
            {
                var tagId = TextHelper.ToUnsignString(t);
                if (!_tagRepository.GetAll(x => x.Id == tagId).Any())
                {
                    var tag = new Tag
                    {
                        Id = tagId,
                        Name = t,
                        Type = CommonConstants.ProductTag
                    };
                    _tagRepository.Add(tag);
                }

                var productTag = new ProductTag
                {
                    TagId = tagId
                };
                productTags.Add(productTag);
            }

            var product = _mapper.Map<Product>(productViewModel);
            var datimeNow = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);
            product.DateCreated = datimeNow;
            product.DateModified = datimeNow;
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
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

        public void AddWholePrice(int productId, List<WholePriceViewModel> wholePrices)
        {
            _wholePriceRepository.RemoveMultiple(_wholePriceRepository.GetAll(x => x.ProductId == productId).ToList());
            foreach (var wholePrice in wholePrices)
            {
                _wholePriceRepository.Add(new WholePrice()
                {
                    ProductId = productId,
                    FromQuantity = wholePrice.FromQuantity,
                    ToQuantity = wholePrice.ToQuantity,
                    Price = wholePrice.Price
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

        public List<WholePriceViewModel> GetWholePrices(int productId)
        {
            var wholePrices = _wholePriceRepository.GetAll(x => x.ProductId == productId);
            var wholePricesViewModel = _mapper.Map<List<WholePriceViewModel>>(wholePrices);
            return wholePricesViewModel;
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

        public List<TagViewModel> GetProductTags(int productId)
        {
            var tags = _tagRepository.GetAll();
            var productTags = _productTagRepository.GetAll();

            var query = from t in tags
                        join pt in productTags
                        on t.Id equals pt.TagId
                        where pt.ProductId == productId
                        select new TagViewModel()
                        {
                            Id = t.Id,
                            Name = t.Name
                        };
            return query.ToList();
        }

        #endregion R

        #region U

        public void Update(ProductViewModel productViewModel)
        {
            var productTags = new List<ProductTag>();
            if (!string.IsNullOrEmpty(productViewModel.Tags))
            {
                var tags = productViewModel.Tags.Split(',');
                foreach (var t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.GetAll(x => x.Id == tagId).Any())
                    {
                        var tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.RemoveMultiple(_productTagRepository.GetAll(x => x.Id == productViewModel.Id).ToList());
                    var productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                }
            }

            var oldProduct = _mapper.Map<Product>(GetById(productViewModel.Id));

            var product = _mapper.Map<Product>(productViewModel);
            product.DateCreated = oldProduct.DateCreated;
            product.DateModified = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);
            foreach (var item in productTags)
            {
                product.ProductTags.Add(item);
            }

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

        public async Task ImportExcelAsync(string filePath, int categoryId)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    var product = new Product();
                    product.CategoryId = categoryId;
                    product.Name = workSheet.Cells[i, 1].Value.ToString();
                    product.Description = workSheet.Cells[i, 2].Value.ToString();
                    product.Status = Status.Active;

                    try
                    {
                        product.Content = workSheet.Cells[i, 6].Value.ToString();
                    }
                    catch (Exception)
                    {
                        product.Content = "";
                    }

                    try
                    {
                        product.SeoKeywords = workSheet.Cells[i, 7].Value.ToString();
                    }
                    catch (Exception)
                    {
                        product.SeoKeywords = "";
                    }

                    try
                    {
                        product.SeoDescription = workSheet.Cells[i, 8].Value.ToString();
                    }
                    catch (Exception)
                    {
                        product.SeoDescription = "";
                    }

                    decimal.TryParse(workSheet.Cells[i, 3].Value.ToString(), out var originalPrice);
                    product.OriginalPrice = originalPrice;

                    decimal.TryParse(workSheet.Cells[i, 4].Value.ToString(), out var price);
                    product.Price = price;

                    decimal.TryParse(workSheet.Cells[i, 5].Value.ToString(), out var promotionPrice);
                    product.PromotionPrice = promotionPrice;

                    bool.TryParse(workSheet.Cells[i, 9].Value.ToString(), out var hotFlag);
                    product.HotFlag = hotFlag;

                    bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out var homeFlag);
                    product.HomeFlag = homeFlag;

                    var dateTimeNow = DateTime.Now;
                    product.DateCreated = ConvertDatetime.ConvertToTimeSpan(dateTimeNow);
                    product.DateModified = ConvertDatetime.ConvertToTimeSpan(dateTimeNow);

                    _productRepository.Add(product);
                    await _unitOfWork.CommitAsync();
                }
            }
        }
    }
}