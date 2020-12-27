using System.ComponentModel.DataAnnotations;

namespace AMZEnterprisePortfolio.Areas.Panel.Models.ViewModels
{
    /// <summary>
    /// User edit ViewModel
    /// </summary>
    public class UserEditVm
    {
        public string Id { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(256)]
        public string UserName { get; set; }
        [MinLength(6)]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [MinLength(6)]
        [MaxLength(30)]
        [Compare(nameof(Password))]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
