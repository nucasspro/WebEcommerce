using NUShop.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUShop.ViewModel.ViewModels
{
    public class SinglePageViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Alias { set; get; }
        public string Content { set; get; }
        public Status Status { set; get; }
    }
}
