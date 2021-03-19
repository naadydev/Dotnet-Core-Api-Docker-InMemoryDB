using CrowdLending.POC.API.Model;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace CrowdLending.POC.API.Repository
{
    public class AppRepository : IAppRepository
    {
        private readonly AppDBContext _dbContext;
        private readonly IConfiguration _configuration;

        public AppRepository(AppDBContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public IEnumerable<Fund> GetAllActiveFunds() => _dbContext.Funds.Where(f => f.IsActive).ToList();

        public Fund GetActiveFundById(long id) => _dbContext.Funds.FirstOrDefault(f => f.IsActive && f.Id == id);

        public IEnumerable<UserInvestment> GetAllUsersInvestments() => _dbContext.UserInvestments.ToList();

        public IEnumerable<UserInvestment> GetUserInvestmentsByUserId(string id) => _dbContext.UserInvestments.Where(inv => inv.UserId == id).ToList();

        public ResponseCategory AddUserInvestment(UserInvestment userInvestment)
        {
            var minAmount = 100;//_configuration.GetValue<decimal>("Investments:Min");
            var maxAmount = 10000;// _configuration.GetValue<decimal>("Investments:Max");

            if (userInvestment.InvestmentPaid < minAmount || userInvestment.InvestmentPaid > maxAmount)
                return ResponseCategory.InvalidInvestmentRang;// Paid Investment must be between 100 and 10,000

            var alreadyExistUserFund = _dbContext.UserInvestments.FirstOrDefault(invs =>
                  invs.FundId == userInvestment.FundId && invs.UserId.Trim() == userInvestment.UserId.Trim());

            if (alreadyExistUserFund != null)
                return ResponseCategory.InvestmentAlreadyExists; // Just for POC purpose

            _dbContext.UserInvestments.Add(userInvestment);
            _dbContext.SaveChanges();
            return ResponseCategory.Succeeded; // Just for POC purpose
        }
    }
}
