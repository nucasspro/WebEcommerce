using FluentValidation;
using NUShop.ViewModel.ViewModels;

namespace NUShop.ViewModel.ViewModelConfiguration
{
    public class ProductValidator : AbstractValidator<ProductViewModel>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.Name).NotEmpty().Length(1, 100);
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).NotNull().NotEmpty().GreaterThanOrEqualTo(5000);
            RuleFor(x => x.Content).NotNull().NotEmpty().Length(1, 500);
            RuleFor(x => x.Unit).NotEmpty().NotNull();
            RuleFor(x => x.DateCreated).Must(date => date != default);
            RuleFor(x => x.DateModified).Must(date => date != default);
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}