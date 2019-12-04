using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;

namespace NUShop.Service.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();
        List<SlideViewModel> GetSlides(string groupAlias);
        SystemConfigViewModel GetSystemConfig(string code);
    }
}
