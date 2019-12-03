using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using WebEcommerce.Data.Entities;
using WebEcommerce.Infrastructure.Interfaces;
using WebEcommerce.Service.Interfaces;
using WebEcommerce.Utility.DTOs;
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

        public PagedResult<UserViewModel> GetAllPaging(string keyword, int pageSize, int pageIndex = 1)
        {
            var users = _userRepository.GetAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                users = users.Where(x => x.Name.Contains(keyword) || x.UserName.Contains(keyword));
            }
            int totalRow = users.Count();

            var users2 = users.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            var usersViewModel = _mapper.Map<List<UserViewModel>>(users2);

            var paginationSet = new PagedResult<UserViewModel>()
            {
                Results = usersViewModel,
                CurrentPage = pageIndex,
                RowCount = totalRow,
                PageSize = pageSize
            };
            return paginationSet;
        }

        public UserViewModel GetById(int id)
        {
            var user = _userRepository.GetById(id);
            var userViewModel = _mapper.Map<UserViewModel>(user);
            return userViewModel;
        }

        public UserViewModel Add(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            _userRepository.Add(user);
            _unitOfWork.CommitAsync();
            var userViewModelReturn = _ma
            return user;
        }

        public void Update(UserViewModel userViewModel)
        {
            var user = _mapper.Map<User>(userViewModel);
            _userRepository.Update(user);
            _unitOfWork.CommitAsync();
        }

        public void Delete(int id)
        {
            var user = _userRepository.GetById(id);
            _userRepository.Remove(user);
            _unitOfWork.CommitAsync();
        }

        #endregion Injections
    }
}