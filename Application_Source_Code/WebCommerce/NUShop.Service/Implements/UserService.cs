using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NUShop.Data.Entities;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.EF.Interfaces;
using NUShop.Utilities.DTOs;
using NUShop.ViewModel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NUShop.Service.EF.Implements
{
    public class UserService : IUserService
    {
        #region Injections

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _mapper = mapper;
        }

        public List<AppUserViewModel> GetAll()
        {
            var users = _userManager.Users;
            var usersViewModel = _mapper.Map<List<AppUserViewModel>>(users);
            return usersViewModel;
        }

        public PagedResult<AppUserViewModel> GetAllPaging(string keyword, int pageSize, int pageIndex = 1)
        {
            var users = _userManager.Users;
            if (!string.IsNullOrEmpty(keyword))
            {
                users = users.Where(x => x.FullName.Contains(keyword) || x.UserName.Contains(keyword) || x.Email.Contains(keyword));
            }
            int totalRow = users.Count();

            var users2 = users.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var usersViewModel = _mapper.Map<List<AppUserViewModel>>(users2);

            var paginationSet = new PagedResult<AppUserViewModel>()
            {
                Results = usersViewModel,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public async Task<AppUserViewModel> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            var roles = await _userManager.GetRolesAsync(user);
            var userViewModel = _mapper.Map<AppUserViewModel>(user);
            userViewModel.Roles = roles.ToList();
            return userViewModel;
        }

        public async Task<bool> AddAsync(AppUserViewModel appUserViewModel)
        {
            try
            {
                var dateTimeNow = DateTime.Now;
                appUserViewModel.DateCreated = dateTimeNow;
                appUserViewModel.DateModified = dateTimeNow;
                var user = _mapper.Map<AppUser>(appUserViewModel);
                var result = await _userManager.CreateAsync(user, appUserViewModel.Password);
                if (result.Succeeded && appUserViewModel.Roles.Count > 0)
                {
                    var appUser = await _userManager.FindByNameAsync(user.UserName);
                    if (appUser != null)
                    {
                        await _userManager.AddToRolesAsync(appUser, appUserViewModel.Roles);
                    }
                    await _unitOfWork.CommitAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task UpdateAsync(AppUserViewModel appUserViewModel)
        {
            var user = await _userManager.FindByIdAsync(appUserViewModel.Id.ToString());
            var currentRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user, appUserViewModel.Roles.Except(currentRoles).AsEnumerable());
            if (result.Succeeded)
            {
                var needRemoveRoles = currentRoles.Except(appUserViewModel.Roles);
                await _userManager.RemoveFromRolesAsync(user, needRemoveRoles);
                user = _mapper.Map<AppUser>(appUserViewModel);
                await _userManager.UpdateAsync(user);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            await _userManager.DeleteAsync(user);
            await _unitOfWork.CommitAsync();
        }

        #endregion Injections
    }
}