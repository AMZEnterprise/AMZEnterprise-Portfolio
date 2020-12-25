using AMZEnterprisePortfolio.Data;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AMZEnterprisePortfolio.Models
{
    /// <summary>
    /// Setting entity
    /// </summary>
    public class Setting : IEntity
    {
        public int Id { get; set; }
        [MaxLength(20)]
        public string PhoneNumber1 { get; set; }
        [MaxLength(20)]
        public string PhoneNumber2 { get; set; }
        [MaxLength(256)]
        [EmailAddress]
        public string Email { get; set; }
        [MaxLength(1000)]
        public string Address { get; set; }
        public Guid CvFilePathGuid { get; set; }
        [NotMapped]
        [Display(Name = "Cv File")]
        public string CvFilePath { get; set; }
        [MaxLength(256)]
        public string FullName { get; set; }
        [MaxLength(1000)]
        public string Qualifications { get; set; }
        [MaxLength(256)]
        public string Slogan { get; set; }
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [MaxLength(256)]
        public string WebsiteUrl1 { get; set; }
        [MaxLength(256)]
        public string WebsiteUrl2 { get; set; }
        [Display(Name = "Educational Degree")]
        [MaxLength(256)]
        public string EducationalDegree { get; set; }
        [Display(Name = "Availability Status")]
        [MaxLength(256)]
        public string AvailabilityStatus { get; set; }
        [Display(Name = "Years Count")]
        public int? YearsCount { get; set; }
        [Display(Name = "Clients Count")]
        public int? ClientsCount { get; set; }
        [Display(Name = "Projects Count")]
        public int? ProjectsCount { get; set; }
    }
}