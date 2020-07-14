using System.ComponentModel.DataAnnotations;


namespace Project1.WebApp.ViewModels
{
    public class CustomerViewModel
    {
        [Display(Name="ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
    }
}
