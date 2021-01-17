using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectDatabase.Domain;
using ProjectDatabase.Repository;
using ProjectDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterConnect.WebAPI.Controllers
{
    [ApiController]
    [Route("/api/interests")]
    public class InterestController : Controller
    {
        IInterestRepository _interestRepo;

        InterestService _interestService;

        public InterestController(IInterestRepository interestRepository)
        {
            this._interestRepo = interestRepository;

            this._interestService = new InterestService(_interestRepo);
        }
        [HttpGet("getAll")]
        public IList<Interest> GetAll()
        {
            return _interestService.GetAll();
        }

        [HttpGet("{interestName}")]
        public ISet<User> GetUsersForInterest(string interestName)
        {
            return _interestService.GetInterestUsers(interestName);
        }

    }
}
