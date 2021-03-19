using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CrowdLending.POC.API.Model
{
    public class BootStrapper
    {
        public static void Initialize()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>().UseInMemoryDatabase("CrowdLendingPOCDB").Options;
            using var context = new AppDBContext(options);

            // Check Already any existing data !!
            if (context.Funds.Any())
                return;   // DB already seeded

            context.Funds.AddRange(GetMockFundsList());

            context.SaveChanges();
        }


        public static List<Fund> GetMockFundsList()
        {
            return new List<Fund>
            {
                new Fund
                 {
                     Id = 1,
                     Title = "Berlin Project 1",
                     InvestmentRequired = 10000000,
                     IsActive = true
                 },
                 new Fund
                 {
                     Id = 2,
                     Title = "Frankfurt Project 2",
                     InvestmentRequired = 5000000,
                     IsActive = true
                 },
                 new Fund
                 {
                     Id = 3,
                     Title = "Munich Project 3",
                     InvestmentRequired = 2500000,
                     IsActive = true
                 }
            };
        }

        public static List<UserInvestment> GetMockUserInvestmentsList()
        {
            return new List<UserInvestment>
            {
                new UserInvestment
                 {
                     Id = 1,
                     FundId= 1,
                     UserId = "9b1deb4d-3b7d-4bad-9bdd-2b0d7b3dcb6f",
                     InvestmentPaid = 200
                 }
            };
        }
    }
}
