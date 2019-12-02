using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebEcommerce.Data.Entities;
using WebEcommerce.Infrastructure.Interfaces;
using WebEcommerce.Model.Enums;
using WebEcommerce.Service.Interfaces;
using WebEcommerce.Utility.Helpers;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Implements
{
    public class BillService : IBillService
    {
        #region Injections

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IRepository<Bill, int> _billRepository;
        private readonly IRepository<BillDetail, int> _billDetailRepository;
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Size, int> _sizeRepository;
        private readonly IRepository<Color, int> _colorRepository;

        public BillService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IRepository<Bill, int> billRepository,
            IRepository<BillDetail, int> billDetailRepository,
            IRepository<Product, int> productRepository,
            IRepository<Size, int> sizeRepository,
            IRepository<Color, int> colorRepository)
        {
            _unitOfWork = unitOfWork;

            _mapper = mapper;
            _billRepository = billRepository;
            _billDetailRepository = billDetailRepository;
            _productRepository = productRepository;
            _sizeRepository = sizeRepository;
            _colorRepository = colorRepository;
        }

        #endregion Injections

        #region C

        public async Task CreateAsync(BillViewModel billViewModel)
        {
            var bill = _mapper.Map<Bill>(billViewModel);
            var billDetails = _mapper.Map<List<BillDetail>>(billViewModel.BillDetails);
            foreach (var item in billDetails)
            {
                var product = _productRepository.GetById(item.ProductId);
                item.Price = product.Price;
            }
            bill.BillDetails = billDetails;
            var dateTimeNow = ConvertDatetime.ConvertToTimeSpan(DateTime.Now);
            bill.DateCreated = dateTimeNow;
            bill.DateModified = dateTimeNow;

            _billRepository.Add(bill);
            await _unitOfWork.CommitAsync();
        }

        public async Task<BillDetailViewModel> CreateDetailAsync(BillDetailViewModel billDetailViewModel)
        {
            var billDetail = _mapper.Map<BillDetail>(billDetailViewModel);
            _billDetailRepository.Add(billDetail);
            await _unitOfWork.CommitAsync();
            return billDetailViewModel;
        }

        #endregion C

        #region R

        public PagedResult<BillViewModel> GetAllPaging(string keyword, int pageSize, string startDate, string endDate, int pageIndex = 1)
        {
            var bills = _billRepository.GetAll();
            if (!string.IsNullOrEmpty(startDate))
            {
                var start = Convert.ToInt32(ConvertDatetime.ConvertToTimeSpan(DateTime.ParseExact(startDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"))));
                bills = bills.Where(x => Convert.ToInt32(x.DateCreated) >= start);
            }
            if (!string.IsNullOrEmpty(endDate))
            {
                var end = Convert.ToInt32(ConvertDatetime.ConvertToTimeSpan(DateTime.ParseExact(endDate, "dd/MM/yyyy", CultureInfo.GetCultureInfo("vi-VN"))));
                bills = bills.Where(x => Convert.ToInt32(x.DateModified) >= end);
            }

            if (!string.IsNullOrEmpty(keyword))
            {
                bills = bills.Where(x => x.CustomerName.Contains(keyword) || x.CustomerMobile.Contains(keyword));
            }

            var totalRow = bills.Count();

            bills = bills.OrderByDescending(x => x.DateCreated).Skip((pageIndex - 1) * pageSize).Take(pageSize);

            var billsViewModel = _mapper.Map<List<BillViewModel>>(bills);

            var paginationSet = new PagedResult<BillViewModel>
            {
                Results = billsViewModel,
                RowCount = totalRow,
                PageSize = pageSize,
                CurrentPage = pageIndex
            };

            return paginationSet;
        }

        public BillViewModel GetDetailById(int billId)
        {
            var bill = _billRepository.GetSingle(x => x.Id == billId);
            var billViewModel = _mapper.Map<BillViewModel>(bill);
            var billDetails = _billDetailRepository.GetAll(x => x.BillId == billId);
            var billDetailsViewModel = _mapper.Map<List<BillDetailViewModel>>(billDetails);
            billViewModel.BillDetails = billDetailsViewModel;
            return billViewModel;
        }

        public List<BillDetailViewModel> GetBillDetails(int billId)
        {
            var billDetails = _billDetailRepository.GetAll(x => x.BillId == billId, c => c.Bill, c => c.Color, c => c.Size, c => c.Product);
            var billDetailsViewModel = _mapper.Map<List<BillDetailViewModel>>(billDetails);
            return billDetailsViewModel;
        }

        public ColorViewModel GetColorById(int id)
        {
            var color = _colorRepository.GetById(id);
            var colorViewModel = _mapper.Map<ColorViewModel>(color);
            return colorViewModel;
        }

        public List<ColorViewModel> GetColors()
        {
            var colors = _colorRepository.GetAll();
            var colorsViewModel = _mapper.Map<List<ColorViewModel>>(colors);
            return colorsViewModel;
        }

        public SizeViewModel GetSizeById(int id)
        {
            var size = _colorRepository.GetById(id);
            var sizeViewModel = _mapper.Map<SizeViewModel>(size);
            return sizeViewModel;
        }

        public List<SizeViewModel> GetSizes()
        {
            var sizes = _sizeRepository.GetAll();
            var sizesViewModel = _mapper.Map<List<SizeViewModel>>(sizes);
            return sizesViewModel;
        }

        #endregion R

        #region U

        public async Task UpdateAsync(BillViewModel billViewModel)
        {
            var bill = _mapper.Map<Bill>(billViewModel);

            // Get order Details
            var newDetails = bill.BillDetails;

            var addedDetails = newDetails.Where(x => x.Id == 0).ToList();

            var updatedDetails = newDetails.Where(x => x.Id != 0).ToList();

            // Get existed details
            var existedDetails = _billDetailRepository.GetAll(x => x.BillId == billViewModel.Id);

            bill.BillDetails.Clear();

            foreach (var item in updatedDetails)
            {
                var product = _productRepository.GetById(item.ProductId);
                item.Price = product.Price;
                _billDetailRepository.Update(item);
            }

            foreach (var item in addedDetails)
            {
                var product = _productRepository.GetById(item.ProductId);
                item.Price = product.Price;
                _billDetailRepository.Add(item);
            }

            _billDetailRepository.RemoveMultiple(existedDetails.Except(updatedDetails).ToList());
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateStatusAsync(int billId, BillStatus status)
        {
            var bill = _billRepository.GetById(billId);
            bill.BillStatus = status;
            _billRepository.Update(bill);
            await _unitOfWork.CommitAsync();
        }

        #endregion U

        #region D

        public async Task DeleteDetailAsync(int productId, int billId, int colorId, int sizeId)
        {
            var billDetail = _billDetailRepository.GetSingle(x => x.ProductId == productId && x.BillId == billId && x.ColorId == colorId && x.SizeId == sizeId);
            _billDetailRepository.Remove(billDetail);
            await _unitOfWork.CommitAsync();
        }

        #endregion D
    }
}