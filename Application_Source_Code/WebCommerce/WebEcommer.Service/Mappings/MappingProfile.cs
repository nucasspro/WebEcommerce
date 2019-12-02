using AutoMapper;
using WebEcommerce.Data.Entities;
using WebEcommerce.Utility.Helpers;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region BillDetail

            CreateMap<BillDetailViewModel, BillDetail>();
            CreateMap<BillDetail, BillDetailViewModel>();

            #endregion BillDetail

            #region Bill

            CreateMap<BillViewModel, Bill>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<Bill, BillViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion Bill

            #region Category

            CreateMap<CategoryViewModel, Category>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<Category, CategoryViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion Category

            #region Color

            CreateMap<ColorViewModel, Color>();
            CreateMap<Color, ColorViewModel>();

            #endregion Color

            #region ProductImage

            CreateMap<ProductImageViewModel, ProductImage>();
            CreateMap<ProductImage, ProductImageViewModel>();

            #endregion ProductImage

            #region ProductQuantity

            CreateMap<ProductQuantityViewModel, ProductQuantity>();
            CreateMap<ProductQuantity, ProductQuantityViewModel>();

            #endregion ProductQuantity

            #region Product

            CreateMap<ProductViewModel, Product>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<Product, ProductViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion Product

            #region Size

            CreateMap<SizeViewModel, Size>();
            CreateMap<Size, SizeViewModel>();

            #endregion Size
        }
    }
}