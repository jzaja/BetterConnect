using ProjectDatabase.Domain;
using ProjectDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Services
{
    public class RequestService
    {
        private IRequestRepository _requestRepository;
        private IUserRepository _userRepository;

        public RequestService(IRequestRepository requestRepo, IUserRepository userRepo)
        {
            this._requestRepository = requestRepo;
            this._userRepository = userRepo;
        }

        public Request GetRequest(int senderId, int receiverId)
        {
            return _requestRepository.GetByKey(senderId, receiverId);
        }

        public Request SendRequest(int senderId, int receiverId)
        {
            // ako request vec postoji
            if (_requestRepository.GetByKey(senderId, receiverId) != null)
            {
                return null;
            }

            User sender = _userRepository.GetUser(senderId);
            User receiver = _userRepository.GetUser(receiverId);

            if (sender == null || receiver == null)
            {
                return null;
            }

            Request req = new Request { SenderId = sender.Id, ReceiverId = receiver.Id, IsConfirmed = false, IsDeclined = false };

            sender.AddRequest(req);
            receiver.AddRequest(req);
            _userRepository.Update(sender);
            _userRepository.Update(receiver);
            return _requestRepository.Save(req);
        }

        public Request UpdateRequest(int senderId, int receiverId, bool requestAccepted, bool requestDenied)
        {
            Request req = _requestRepository.GetByKey(senderId, receiverId);

            if (req == null)
            {
                return null;
            }

            User sender = _userRepository.GetUser(senderId);
            User receiver = _userRepository.GetUser(receiverId);

            // i can accept the request only if i am receiver 
            if (IsLogicRight(sender, senderId, receiver, receiverId))
            {
                req.IsConfirmed = requestAccepted;
                req.IsDeclined = requestDenied;
                return _requestRepository.Update(req);
            }

            return null;
        }

        private bool IsLogicRight(User sender, int senderId, User receiver, int receiverId)
        {
            return receiver.Id == receiver.Id && sender.Id == senderId;
        }

        public IList<Request> GetSent(int senderId)
        {
            return GetRequests(senderId, true);
        }

        public IList<Request> GetReceived(int receiverId)
        {
            return GetRequests(receiverId, false);
        }

        private IList<Request> GetRequests(int userId, bool isSender)
        {
            var user = _userRepository.GetUser(userId);
            if (user == null)
            {
                return null;
            }

            var userRequests = user.Requests;

            var wanted = new List<Request>();
            foreach (Request req in userRequests)
            {
                if (isSender)
                {
                    if (req.SenderId == user.Id)
                    {
                        wanted.Add(req);
                    }
                } else
                {
                    if (req.ReceiverId == user.Id)
                    {
                        wanted.Add(req);
                    }
                }
                
            }

            return wanted;
        }

    }
}
