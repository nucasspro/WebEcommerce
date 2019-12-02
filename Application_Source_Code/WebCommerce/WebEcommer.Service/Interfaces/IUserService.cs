using System.Collections.Generic;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll();

        PagedResult<UserViewModel> GetAllPaging(string keyword, int pageIndex, int pageSize);

        UserViewModel GetById(string id);

        UserViewModel Add(UserViewModel appUserViewModel);

        void Update(UserViewModel appUserViewModel);

        void Delete(string id);
    }
}