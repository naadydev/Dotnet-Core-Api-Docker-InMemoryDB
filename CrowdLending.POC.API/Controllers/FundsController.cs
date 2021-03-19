using CrowdLending.POC.API.Model;
using CrowdLending.POC.API.Repository;
using Microsoft.AspNetCore.Mvc;


namespace CrowdLending.POC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FundsController : ControllerBase
    {
        private readonly IAppRepository _repository;

        public FundsController(IAppRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("/api/funds")]
        public IActionResult GetAllActiveFunds()
        {
            return Ok(_repository.GetAllActiveFunds());
        }

        [HttpGet("/api/funds/{id}")]
        public IActionResult GetActiveFundById(long id)
        {
            return Ok(_repository.GetActiveFundById(id));
        }

        [HttpPost("/api/funds")]
        public IActionResult PostUserInvestment([FromBody] UserInvestment investment)
        {
            var result = _repository.AddUserInvestment(investment);

            if (result != ResponseCategory.Succeeded)
                return BadRequest(result); // In order to show proper error message in the Frontend.

            return Ok(result);
        }


        #region Investments

        [HttpGet("/api/investments")]
        public IActionResult GetAllInvestments()
        {
            return Ok(_repository.GetAllUsersInvestments());
        }

        [HttpGet("/api/investments/{id}")]
        public IActionResult GetUserInvestmentsByUserId(string id)
        {
            return Ok(_repository.GetUserInvestmentsByUserId(id));
        }

        #endregion

    }
}
