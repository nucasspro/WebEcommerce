using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NUShop.Service.EF.Interfaces
{
    public interface IRoleService
    {
        List<AppRoleViewModel> GetAll();
        Task<AppRoleViewModel> GetByIdAsync(Guid id);
        PagedResult<AppRoleViewModel> GetAllPaging(string keyword, int pageSize, int pageIndex = 1);
        List<PermissionViewModel> GetAllFunction(Guid roleId);
        Task<bool> AddAsync(AnnouncementViewModel announcement, List<AnnouncementUserViewModel> announcementUsers, AppRoleViewModel roleVm);
        Task UpdateAsync(AppRoleViewModel userVm);
        void UpdatePermission(List<PermissionViewModel> permissions, Guid roleId);
        Task DeleteAsync(Guid id);
        Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}
