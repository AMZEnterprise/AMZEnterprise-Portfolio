using System;
using System.ComponentModel.DataAnnotations;
using AMZEnterprisePortfolio.Data;

namespace AMZEnterprisePortfolio.Models
{
    /// <summary>
    /// Contact entity
    /// </summary>
    public class Contact : IEntity
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(256)]
        public string FullName { get; set; }
        [Required]
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MaxLength(256)]
        public string Subject { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Message { get; set; }
        [MaxLength(256)]
        public string Ip { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
