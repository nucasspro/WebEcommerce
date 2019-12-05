using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Utilities.Helpers;
using NUShop.ViewModel.ViewModels;

namespace NUShop.Service.Dapper.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region AnnouncementUser

            CreateMap<AnnouncementUserViewModel, AnnouncementUser>();
            CreateMap<AnnouncementUser, AnnouncementUserViewModel>();

            #endregion AnnouncementUser

            #region Announcement

            CreateMap<AnnouncementViewModel, Announcement>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<Announcement, AnnouncementViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion Announcement

            #region AppRole

            CreateMap<AppRoleViewModel, AppRole>();
            CreateMap<AppRole, AppRoleViewModel>();

            #endregion AppRole

            #region AppUser

            CreateMap<AppUserViewModel, AppUser>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<AppUser, AppUserViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion AppUser

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

            #region BlogTag

            CreateMap<BlogTagViewModel, BlogTag>();
            CreateMap<BlogTag, BlogTagViewModel>();

            #endregion BlogTag

            #region Blog

            CreateMap<BlogViewModel, Blog>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<Blog, BlogViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion Blog

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

            #region Contact

            CreateMap<ContactViewModel, Contact>();
            CreateMap<Contact, ContactViewModel>();

            #endregion Contact

            #region Feedback

            CreateMap<FeedbackViewModel, Feedback>()
                .ForMember(model => model.DateCreated,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateCreated)))
                .ForMember(model => model.DateModified,
                    opt => opt.MapFrom(viewmodel => ConvertDatetime.ConvertToTimeSpan(viewmodel.DateModified)));
            CreateMap<Feedback, FeedbackViewModel>()
                .ForMember(viewmodel => viewmodel.DateCreated,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateCreated)))
                .ForMember(viewmodel => viewmodel.DateModified,
                    opt => opt.MapFrom(model => ConvertDatetime.UnixTimestampToDateTime(model.DateModified)));

            #endregion Feedback

            #region Footer

            CreateMap<FooterViewModel, Footer>();
            CreateMap<Footer, FooterViewModel>();

            #endregion Footer

            #region Function

            CreateMap<FunctionViewModel, Function>();
            CreateMap<Function, FunctionViewModel>();

            #endregion Function

            #region Permission

            CreateMap<PermissionViewModel, Permission>();
            CreateMap<Permission, PermissionViewModel>();

            #endregion Permission

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

            #region SinglePage

            CreateMap<SinglePageViewModel, SinglePage>();
            CreateMap<Feedback, SinglePageViewModel>();

            #endregion SinglePage

            #region Size

            CreateMap<SizeViewModel, Size>();
            CreateMap<Size, SizeViewModel>();

            #endregion Size

            #region Slide

            CreateMap<SlideViewModel, Slide>();
            CreateMap<Slide, SlideViewModel>();

            #endregion Slide

            #region SystemConfig

            CreateMap<SystemConfigViewModel, SystemConfig>();
            CreateMap<SystemConfig, SystemConfigViewModel>();

            #endregion SystemConfig

            #region Tag

            CreateMap<TagViewModel, Tag>();
            CreateMap<Tag, TagViewModel>();

            #endregion Tag

            #region WholePrice

            CreateMap<WholePriceViewModel, WholePrice>();
            CreateMap<WholePrice, WholePriceViewModel>();

            #endregion WholePrice
        }
    }
}