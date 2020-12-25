using AMZEnterprisePortfolio.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMZEnterprisePortfolio.Models
{
    /// <summary>
    /// Portfolio entity
    /// </summary>
    public class Portfolio : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [Display(Name = "Short Description")]
        [Required]
        [MaxLength(1000)]
        public string ShortDescription { get; set; }
        [Required]
        public string Description { get; set; }
        [Display(Name = "Employer FullName")]
        [Required]
        [MaxLength(256)]
        public string EmployerFullName { get; set; }
        [Required]
        [MaxLength(256)]
        public string Technologies { get; set; }
        public Guid FilePathGuid { get; set; }
        [NotMapped]
        [Display(Name = "Portfolio Image")]
        public string FilePath { get; set; }
        [Display(Name = "Portfolio Type")]
        public PortfolioType PortfolioType { get; set; }
    }
}
