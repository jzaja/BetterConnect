using NHibernate;
using ProjectDatabase.Domain;
using ProjectDatabase.HibernateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectDatabase.Repository.ConcreteRepository
{
    public class RequestRepository : IRequestRepository
    {
        private ISession _session;

        public RequestRepository(INHibernateHelper helper)
        {
            _session = helper.OpenSession();
        }

        public Request Save(Request request)
        {
            _session.Save(request);
            _session.BeginTransaction().Commit();
            return request;
        }

        public long RowCount()
        {
            return _session.QueryOver<Request>().RowCountInt64();
        }

        public Request ApproveRequest(Request request)
        {
            throw new NotImplementedException();
        }

        public Request DeclineRequest(Request request)
        {
            throw new NotImplementedException();
        }

    }
}
