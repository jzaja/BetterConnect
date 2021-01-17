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
    public class AuthController : Controller
    {
        IUserRepository _userRepo;
        IInterestRepository _interestRepo;

        AuthService _authService;
        UserService _userService;

        public AuthController(IUserRepository userRepository, IInterestRepository interestRepository)
        {
            this._userRepo = userRepository;
            this._interestRepo = interestRepository;

            _authService = new AuthService(_userRepo);
            _userService = new UserService(_userRepo, _interestRepo);
        }

        [HttpGet("getAll")]
        public IList<User> GetAll()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost("register")]
        public BasicUser Register(RegisterUserDTO registerUserDTO)
        {
            return _authService.Register(registerUserDTO.Username, registerUserDTO.Password, registerUserDTO.PhoneNumber);
        }

        [HttpGet("login")]
        public BasicUser Login(LoginUserDTO loginUserDTO)
        {
            return _authService.Login(loginUserDTO.Username, loginUserDTO.Password);
        }

    }
}
