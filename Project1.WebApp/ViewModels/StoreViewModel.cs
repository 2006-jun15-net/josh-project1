using Project1.Library.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Project1.WebApp.ViewModels
{
    public class StoreViewModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }
        [Display(Name = "Store")]
        public string StoreName { get; set; }
        [Display(Name = "Address")]
        public string StoreAddress { get; set; }
        [Display(Name = "Inventory")]
        public List<ProductEntity> Inventory { get; set; }
    }   
}
