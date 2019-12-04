using AutoMapper;
using NUShop.Data.Entities;
using NUShop.Infrastructure.Interfaces;
using NUShop.Service.Interfaces;
using NUShop.Utilities.Constants;
using NUShop.ViewModel.ViewModels;
using System.Collections.Generic;

namespace NUShop.Service.Implements
{
    public class CommonService : ICommonService
    {
        #region Injections

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Footer, string> _footerRepository;
        private readonly IRepository<Slide, int> _slideRepository;
        private readonly IRepository<SystemConfig, string> _systemConfigRepository;

        public CommonService(IUnitOfWork unitOfWork, IMapper mapper, IRepository<Footer, string> footerRepository, IRepository<Slide, int> slideRepository, IRepository<SystemConfig, string> systemConfigRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _footerRepository = footerRepository;
            _slideRepository = slideRepository;
            _systemConfigRepository = systemConfigRepository;
        }

        #endregion Injections

        public FooterViewModel GetFooter()
        {
            var footer = _footerRepository.GetSingle(x => x.Id == CommonConstants.DefaultFooterId);
            var footerViewModel = _mapper.Map<FooterViewModel>(footer);
            return footerViewModel;
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            var slides = _slideRepository.GetAll(x => x.GroupAlias == groupAlias && x.Status);
            var slidesViewModel = _mapper.Map<List<SlideViewModel>>(slides);
            return slidesViewModel;
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            var config = _systemConfigRepository.GetSingle(x => x.Id == code);
            var configViewModel = _mapper.Map<SystemConfigViewModel>(config);
            return configViewModel;
        }
    }
}