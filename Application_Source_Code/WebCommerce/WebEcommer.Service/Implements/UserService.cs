using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data.Entities;
using WebEcommerce.Infrastructure.Interfaces;
using WebEcommerce.Service.Interfaces;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Implements
{
    public class UserService : IUserService
    {
        #region Injections

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<User, int> _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, IRepository<User, int> userRepository, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public List<UserViewModel> GetAll()
        {
            var users = _userRepository.GetAll().OrderBy(x => x.Id);
            var usersViewModel = _mapper.Map<List<UserViewModel>>(users);
            return usersViewModel;
        }

        public PagedResult<User> GetAllPaging(string keyword, int pageSize, int pageIndex = 1)
        {
            var users = _userRepository.Users;
            if (!string.IsNullOrEmpty(keyword))
            {
                users = users.Where(x => x.FullName.Contains(keyword) || x.UserName.Contains(keyword) || x.Email.Contains(keyword));
            }
            int totalRow = users.Count();

            var users2 = users.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var usersViewModel = _mapper.Map<List<User>>(users2);

            var paginationSet = new PagedResult<User>()
            {
                Results = usersViewModel,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public UserViewModel GetById(string id)
        {
            var user = _userRepository.GetById(id);
            var roles = await _userManager.GetRolesAsync(user);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            userViewModel.Roles = roles.ToList();
            return userViewModel;
        }

        public async Task<bool> AddAsync(User userViewModel)
        {
            try
            {
                var dateTimeNow = DateTime.Now;
                userViewModel.DateCreated = dateTimeNow;
                userViewModel.DateModified = dateTimeNow;
                var user = _mapper.Map<AppUser>(userViewModel);
                var result = await _userManager.CreateAsync(user, userViewModel.Password);
                if (result.Succeeded && userViewModel.Roles.Count > 0)
                {
                    var appUser = await _userManager.FindByNameAsync(user.UserName);
                    if (appUser != null)
                    {
                        await _userManager.AddToRolesAsync(appUser, userViewModel.Roles);
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

        public async Task UpdateAsync(User userViewModel)
        {
            var user = await _userManager.FindByIdAsync(userViewModel.Id.ToString());
            var currentRoles = await _userManager.GetRolesAsync(user);

            var result = await _userManager.AddToRolesAsync(user, userViewModel.Roles.Except(currentRoles).AsEnumerable());
            if (result.Succeeded)
            {
                var needRemoveRoles = currentRoles.Except(userViewModel.Roles);
                await _userManager.RemoveFromRolesAsync(user, needRemoveRoles);
                user = _mapper.Map<User>(userViewModel);
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