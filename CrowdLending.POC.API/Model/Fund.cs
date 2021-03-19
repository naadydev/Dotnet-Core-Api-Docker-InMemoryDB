using System.ComponentModel.DataAnnotations;

namespace CrowdLending.POC.API.Model
{
    public class Fund
    {
        [Key]
        [Required(ErrorMessage = "{0} Required")]
        public long Id { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        public decimal InvestmentRequired { get; set; }

        public bool IsActive { get; set; }
    }
}
