using System.Collections.Generic;

namespace AMZEnterprisePortfolio.Models.ViewModels
{
    /// <summary>
    /// Home ViewModel
    /// </summary>
    public class HomeVm
    {
        public Contact Contact { get; set; }
        public Setting Setting { get; set; }
        public IList<SocialMedia>SocialMedias { get; set; }
        public IList<Favor> Favors { get; set; }
        public IList<Resume> Resumes { get; set; }
        public IList<Skill> Skills { get; set; }
        public IList<Portfolio> Portfolios { get; set; }
    }
}
