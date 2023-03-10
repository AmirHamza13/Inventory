using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    public class Registration
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "User Name")]
        [Required(ErrorMessage = "User Name is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "User Name be a minimum length of 6 and a maximum length of 100")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be a minimum length of 6 and a maximum length of 20")]
        public string Password { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(100, ErrorMessage = "First Name must be a maximum length of 100")]
        public string UserFirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(100, ErrorMessage = "Last Name must be a maximum length of 100")]
        public string? UserLastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Email is not Valid")]
        public string? Email { get; set; }
        [Display(Name = "Contact No.")]
        [Required(ErrorMessage = "Contact No. is required in intiger values")]
        public int Phone { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Address is required")]
        [StringLength(100, ErrorMessage = "Address must be a maximum length of 100")]
        public string Address { get; set; }
    }
}
