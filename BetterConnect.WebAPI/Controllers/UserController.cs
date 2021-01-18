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
    [Route("/api/users")]
    public class UserController : Controller
    {
        IUserRepository _userRepo;
        IInterestRepository _interestRepo;

        AuthService _authService;
        UserService _userService;

        public UserController(IUserRepository userRepository, IInterestRepository interestRepository)
        {
            this._userRepo = userRepository;
            this._interestRepo = interestRepository;

            _authService = new AuthService(_userRepo);
            _userService = new UserService(_userRepo, _interestRepo);
        }

        [HttpPut("addInterest")]
        public User AddInterest(InterestUpdateDTO interestUpdateDTO)
        {
            return _userService.AddInterest(interestUpdateDTO.UserId, interestUpdateDTO.InterestName);
        }

        [HttpPut("removeInterest")]
        public User RemoveInterest(InterestUpdateDTO interestUpdateDTO)
        {
            return _userService.RemoveInterest(interestUpdateDTO.UserId, interestUpdateDTO.InterestName);
        }

        [HttpPut("blockUser/{adminId}/{userId}")]
        public User BlockUser(int adminId, int userId)
        {
            return _userService.BlockUser(adminId, userId);
        }

    }
}
