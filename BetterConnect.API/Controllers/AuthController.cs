using Microsoft.AspNetCore.Mvc;
using ProjectDatabase.Domain;
using ProjectDatabase.HibernateHelper;
using ProjectDatabase.Repository;
using ProjectDatabase.Repository.ConcreteRepository;
using ProjectDatabase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetterConnect.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserRepository _userRepo = new UserRepository(new SQLNHibernateHelper());
        private IInterestRepository _interestRepo = new InterestRepository(new SQLNHibernateHelper());
        private AuthService _authService;
        private UserService _userService;

        public AuthController()
        {
            _authService = new AuthService(_userRepo);
            _userService = new UserService(_userRepo, _interestRepo);
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            
            return new[]
            {
            new User{ Username = "misko", Password = "dada", PhoneNumber = "desii" }
        };
        }

    }
}
