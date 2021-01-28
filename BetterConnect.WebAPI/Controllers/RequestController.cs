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
    [Route("/api/requests")]
    public class RequestController : Controller
    {
        private IRequestRepository _requestRepo;
        private IUserRepository _userRepo;

        private RequestService _requestService;

        public RequestController(IRequestRepository requestRepository, IUserRepository userRepository)
        {
            this._requestRepo = requestRepository;
            this._userRepo = userRepository;

            this._requestService = new RequestService(_requestRepo, _userRepo);
        }

        [HttpGet("getAll")]
        public IList<Request> GetAll()
        {
            return _requestRepo.GetAll();
        }

        [HttpPost("sendRequest")]
        public Request SendRequest(SendRequestDTO sendRequestDTO)
        {
            return _requestService.SendRequest(sendRequestDTO.SenderId, sendRequestDTO.ReceiverId);
        }

        [HttpPut("approveRequest")]
        public Request ApproveRequest(SendRequestDTO sendRequestDTO)
        {
            return _requestService.UpdateRequest(sendRequestDTO.SenderId, sendRequestDTO.ReceiverId, true, false);
        }

        [HttpPut("declineRequest")]
        public Request DeclineRequest(SendRequestDTO sendRequestDTO)
        {
            return _requestService.UpdateRequest(sendRequestDTO.SenderId, sendRequestDTO.ReceiverId, false, true);
        }

        [HttpGet("get/{senderId}/{receiverId}")]
        public Request GetRequest(int senderId, int receiverId)
        {
            return _requestService.GetRequest(senderId, receiverId);
        }

        // returns requests that was sent by senderId
        [HttpGet("getSent/{senderId}")]
        public IList<Request> GetSentBy(int senderId)
        {
            return _requestService.GetSent(senderId);
        }

        [HttpGet("getReceived/{receiverId}")]
        public IList<Request> GetReceivedBy(int receiverId)
        {
            return _requestService.GetReceived(receiverId);
        }

    }
}
