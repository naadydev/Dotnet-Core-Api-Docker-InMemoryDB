using CrowdLending.POC.API.Model;
using System.Collections.Generic;

namespace CrowdLending.POC.API.Repository
{
    public interface IAppRepository
    {
        public IEnumerable<Fund> GetAllActiveFunds();
        public Fund GetActiveFundById(long id);
        public ResponseCategory AddUserInvestment(UserInvestment userInvestment);
        public IEnumerable<UserInvestment> GetAllUsersInvestments();
        public IEnumerable<UserInvestment> GetUserInvestmentsByUserId(string id);
    }
}
