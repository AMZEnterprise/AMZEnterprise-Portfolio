using AMZEnterprisePortfolio.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace AMZEnterprisePortfolio.Models
{
    /// <summary>
    /// Resume entity
    /// </summary>
    public class Resume : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }
        [Display(Name = "Resume Type")]
        public ResumeType ResumeType { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
