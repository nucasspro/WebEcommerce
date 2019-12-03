using System.Collections.Generic;
using WebEcommerce.Utility.DTOs;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAll();

        PagedResult<UserViewModel> GetAllPaging(string keyword, int pageIndex, int pageSize);

        UserViewModel GetById(int id);

        UserViewModel Add(UserViewModel appUserViewModel);

        void Update(UserViewModel appUserViewModel);

        void Delete(int id);
    }
}