using FluentValidation;
using NUShop.ViewModel.ViewModels;

namespace NUShop.ViewModel.ViewModelConfiguration
{
    public class CategoryValidator : AbstractValidator<CategoryViewModel>
    {
        public CategoryValidator()
        {
            //RuleFor(x => x.Name).NotNull().NotEmpty().Length(1, 50);
            //RuleFor(x => x.Description).MaximumLength(200);
            //RuleFor(x => x.Image).MaximumLength(100);
            ////RuleFor(x => x.CategoryStatusTypeId).GreaterThanOrEqualTo(1).LessThanOrEqualTo(2);
            //RuleFor(x => x.InsertedAt);
            //RuleFor(x => x.UpdatedAt);
            RuleFor(x => x.Name).Length(1, 255);
            RuleFor(x => x.Description);
            //public int? ParentId { get; set; }
            //public int? HomeOrder { get; set; }
            //public string Image { get; set; }
            //public bool? HomeFlag { get; set; }
            //public DateTime DateCreated { set; get; }
            //public DateTime DateModified { set; get; }
            //public int SortOrder { set; get; }
            //public Status Status { set; get; }
            //public string SeoPageTitle { set; get; }
            //public string SeoAlias { set; get; }
            //public string SeoKeywords { set; get; }
            //public string SeoDescription { set; get; }
        }
    }
}