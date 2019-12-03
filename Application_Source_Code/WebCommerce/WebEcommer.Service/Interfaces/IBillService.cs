using System.Collections.Generic;
using System.Threading.Tasks;
using WebEcommerce.Model.Enums;
using WebEcommerce.Utility.DTOs;
using WebEcommerce.ViewModel.ViewModels;

namespace WebEcommerce.Service.Interfaces
{
    public interface IBillService
    {
        PagedResult<BillViewModel> GetAllPaging(string keyword, int pageSize, string startDate, string endDate, int pageIndex = 1);

        BillViewModel GetDetailById(int id);

        List<BillDetailViewModel> GetBillDetails(int billId);

        List<ColorViewModel> GetColors();

        ColorViewModel GetColorById(int id);

        List<SizeViewModel> GetSizes();

        SizeViewModel GetSizeById(int id);

        Task<BillDetailViewModel> CreateDetailAsync(BillDetailViewModel billDetailVm);

        Task CreateAsync(BillViewModel billVm);

        Task UpdateAsync(BillViewModel billVm);

        Task UpdateStatusAsync(int orderId, BillStatus status);

        Task DeleteDetailAsync(int productId, int billId, int colorId, int sizeId);
    }
}