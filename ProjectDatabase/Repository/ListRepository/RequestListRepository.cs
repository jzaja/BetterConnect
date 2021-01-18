using ProjectDatabase.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Repository.ListRepository
{
    public class RequestListRepository : IRequestRepository
    {
        private IList<Request> _requests = new List<Request>();

        public IList<Request> GetAll()
        {
            return _requests;
        }

        public Request ApproveRequest(Request request)
        {
            request.IsConfirmed = true;
            return request;
        }

        public Request DeclineRequest(Request request)
        {
            request.IsDeclined = true;
            return request;
        }

        public Request GetByKey(int senderId, int receiverId)
        {
            foreach (Request req in _requests)
            {
                if (req.SenderId == senderId && req.ReceiverId == receiverId)
                {
                    return req;
                }
            }

            return null;
        }

        public long RowCount()
        {
            return _requests.Count;
        }

        public Request Save(Request request)
        {
            _requests.Add(request);
            return request;
        }

        public Request Update(Request request)
        {
            return request;
        }
    }
}
