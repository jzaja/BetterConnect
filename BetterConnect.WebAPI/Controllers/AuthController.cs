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
    [Route("/api/auth")]
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
        public IList<BasicUser> GetAll()
        {
            return _userService.GetAll();
        }

        [HttpGet("getAllUsers")]
        public IList<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }

        [HttpPost("register")]
        public BasicUser Register(RegisterUserDTO registerUserDTO)
        {
            return _authService.Register(registerUserDTO.Username, registerUserDTO.Password, registerUserDTO.PhoneNumber);
        }

        [HttpPost("registerAdmin")]
        public Admin RegisterAdmin(RegisterAdminDTO registerAdminDTO)
        {
            return _authService.RegisterAdmin(registerAdminDTO.Password);
        }

        [HttpPost("login")]
        public BasicUser Login(LoginUserDTO loginUserDTO)
        {
            return _authService.Login(loginUserDTO.Username, loginUserDTO.Password);
        }

        [HttpPut("blockUser")]
        public User Block(BlockUserDTO blockUserDTO)
        {
            return _userService.BlockUser(blockUserDTO.AdminId, blockUserDTO.UserId);
        }

    }
}
