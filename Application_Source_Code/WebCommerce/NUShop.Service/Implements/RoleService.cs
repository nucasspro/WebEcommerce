using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NUShop.Data.Entities;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.Service.Implements
{
    public class RoleService : IRoleService
    {
        #region Injections

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IRepository<Permission, int> _permissionRepository;
        private readonly IRepository<Function, string> _functionRepository;
        private readonly IRepository<Announcement, string> _announRepository;
        private readonly IRepository<AnnouncementUser, int> _announUserRepository;


        public RoleService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            RoleManager<AppRole> roleManager,
            IRepository<Permission, int> permissionRepository,
            IRepository<Function, string> functionRepository,
            IRepository<Announcement, string> announRepository,
            IRepository<AnnouncementUser, int> announUserRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleManager = roleManager;
            _permissionRepository = permissionRepository;
            _functionRepository = functionRepository;
            _announRepository = announRepository;
            _announUserRepository = announUserRepository;
        }

        public List<AppRoleViewModel> GetAll()
        {
            var roles = _roleManager.Roles;
            var rolesViewModel = _mapper.Map<List<AppRoleViewModel>>(roles);
            return rolesViewModel;
        }

        public async Task<AppRoleViewModel> GetByIdAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            var roleViewModel = _mapper.Map<AppRoleViewModel>(role);
            return roleViewModel;
        }

        public PagedResult<AppRoleViewModel> GetAllPaging(string keyword, int pageSize, int pageIndex = 1)
        {
            var roles = _roleManager.Roles;
            if (!string.IsNullOrEmpty(keyword))
            {
                roles = roles.Where(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }

            var totalRow = roles.Count();
            roles = roles.Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var rolesViewModel = _mapper.Map<List<AppRoleViewModel>>(roles);
            var paginationSet = new PagedResult<AppRoleViewModel>()
            {
                Results = rolesViewModel,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public async Task<bool> AddAsync(AnnouncementViewModel announcementViewModel, List<AnnouncementUserViewModel>  announcementUserViewModels, AppRoleViewModel appRoleViewModel)
        {
            var role = new AppRole()
            {
                Name = appRoleViewModel.Name,
                Description = appRoleViewModel.Description
            };
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                var announcement = _mapper.Map<Announcement>(announcementViewModel);
                _announRepository.Add(announcement);
                foreach (var userVm in announcementUserViewModels)
                {
                    var user = _mapper.Map<AnnouncementUser>(userVm);
                    _announUserRepository.Add(user);
                }
                _unitOfWork.Commit();
            }
            return result.Succeeded;
        }

        public async Task UpdateAsync(AppRoleViewModel appRoleViewModel)
        {
            var roles = await _roleManager.FindByIdAsync(appRoleViewModel.Id.ToString());
            roles.Name = appRoleViewModel.Name;
            roles.Description = appRoleViewModel.Description;
            await _roleManager.UpdateAsync(roles);
            await _unitOfWork.CommitAsync();
        }

        public void UpdatePermission(List<PermissionViewModel> permissionVms, Guid roleId)
        {
            var permissions = _mapper.Map<List<Permission>>(permissionVms);
            var oldPermission = _permissionRepository.GetAll().Where(x => x.RoleId == roleId).ToList();
            if (oldPermission.Count > 0)
            {
                _permissionRepository.RemoveMultiple(oldPermission);
            }
            foreach (var permission in permissions)
            {
                _permissionRepository.Add(permission);
            }
            _unitOfWork.Commit();
        }

        public async Task DeleteAsync(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(role);
            await _unitOfWork.CommitAsync();
        }

        public Task<bool> CheckPermission(string functionId, string action, string[] roles)
        {
            var functions = _functionRepository.GetAll();
            var permissions = _permissionRepository.GetAll();
            var query = from f in functions
                        join p in permissions on f.Id equals p.FunctionId
                        join r in _roleManager.Roles on p.RoleId equals r.Id
                        where roles.Contains(r.Name) && f.Id == functionId
                        && ((p.CanCreate && action == "Create")
                        || (p.CanUpdate && action == "Update")
                        || (p.CanDelete && action == "Delete")
                        || (p.CanRead && action == "Read"))
                        select p;
            return query.AnyAsync();
        }

        public List<PermissionViewModel> GetAllFunction(Guid roleId)
        {
            var functions = _functionRepository.GetAll();
            var permissions = _permissionRepository.GetAll();

            var query = from f in functions
                        join p in permissions on f.Id equals p.FunctionId into fp
                        from p in fp.DefaultIfEmpty()
                        where p != null && p.RoleId == roleId
                        select new PermissionViewModel()
                        {
                            RoleId = roleId,
                            FunctionId = f.Id,
                            CanCreate = p != null ? p.CanCreate : false,
                            CanDelete = p != null ? p.CanDelete : false,
                            CanRead = p != null ? p.CanRead : false,
                            CanUpdate = p != null ? p.CanUpdate : false
                        };
            return query.ToList();
        }

        #endregion Injections
    }
}