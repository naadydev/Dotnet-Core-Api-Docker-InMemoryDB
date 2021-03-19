using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrowdLending.POC.API.Model
{
    public class UserInvestment
    {
        /// <summary>
        /// **** Note : I put Nullable operatore ? in the Entity to use and validate DataAnnotations, 
        ///             In production we could transfere that into DTO Layer and keep the Original Entity required. 
        /// </summary>


        [Key]
        [Required(ErrorMessage = "{0} Required")]
        public long Id { get; set; }
        // ----------

        [Required(ErrorMessage = "{0} Required")]
        public long? FundId { get; set; }

        [ForeignKey("FundId")]
        public virtual Fund Fund { get; set; }

        // ----------
        /// <summary>
        /// Note: Just for the purpose of the POC we did not add User Entity relation here, in real Production version 
        /// we colud connect with real user store 
        /// </summary>
        [Required(ErrorMessage = "{0} Required")]
        public string UserId { get; set; }

        // ----------
        [Required(ErrorMessage = "{0} Required")]
        [Range(100, 10000, ErrorMessage = "Paid Investment must be between {1} and {2}")]
        public decimal InvestmentPaid { get; set; }
    }
}
