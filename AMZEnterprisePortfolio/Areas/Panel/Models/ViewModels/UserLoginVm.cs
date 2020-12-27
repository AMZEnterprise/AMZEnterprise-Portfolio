using System.ComponentModel.DataAnnotations;

namespace AMZEnterprisePortfolio.Areas.Panel.Models.ViewModels
{
    /// <summary>
    /// User login ViewModel
    /// </summary>
    public class UserLoginVm
    {
        [Required]
        [MaxLength(30)]
        public string UserName { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(30)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
