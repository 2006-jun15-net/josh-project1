using Project1.Library.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Project1.WebApp.ViewModels
{
    public class OrderViewModel
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [Required]
        [Display(Name = "Store ID")]
        [Range(1, 999)]
        public int StoreId { get; set; }
        [Required]
        [Display(Name = "Customer ID")]
        [Range(1, 999)]
        public int CustomerId { get; set; }
        [Display(Name = "Orders")]
        public Dictionary<ProductEntity, int> Orders { get; set; }
    }
}
