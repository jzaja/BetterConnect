using System;
using System.Collections.Generic;
using System.Text;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Repository
{
    public interface IRequestRepository
    {
        IList<Request> GetAll();
        Request Save(Request request);
        Request Update(Request request);
        Request GetByKey(int senderId, int receiverId);
        long RowCount();
        Request ApproveRequest(Request request);
        Request DeclineRequest(Request request);
    }
}
