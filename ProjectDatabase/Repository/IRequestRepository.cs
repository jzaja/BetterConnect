using System;
using System.Collections.Generic;
using System.Text;
using ProjectDatabase.Domain;

namespace ProjectDatabase.Repository
{
    public interface IRequestRepository
    {
        Request Save(Request request);
        long RowCount();
        Request ApproveRequest(Request request);
        Request DeclineRequest(Request request);
    }
}
