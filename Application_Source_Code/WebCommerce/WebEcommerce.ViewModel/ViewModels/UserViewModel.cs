using System.Collections.Generic;
using WebEcommerce.Model.Enums;

namespace WebEcommerce.ViewModel.ViewModels
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public virtual ICollection<BillViewModel> Bills { get; set; }
    }
}