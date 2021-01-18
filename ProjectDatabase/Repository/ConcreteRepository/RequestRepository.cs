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
            using (var tx = _session.BeginTransaction())
            {
                _session.Save(request);
                tx.Commit();
                return request;
            }
        }

        public Request Update(Request request)
        {
            using (var tx = _session.BeginTransaction())
            {
                _session.Update(request);
                tx.Commit();
                return request;
            }
        }

        public long RowCount()
        {
            return _session.QueryOver<Request>().RowCountInt64();
        }

        public Request ApproveRequest(Request request)
        {
            request.IsConfirmed = true;
            return Update(request);
        }

        public Request DeclineRequest(Request request)
        {
            request.IsDeclined = true;
            return Save(request);
        }

        public Request GetByKey(int senderId, int receiverId)
        {
            return _session.Query<Request>().Where(x => x.SenderId == senderId && x.ReceiverId == receiverId).SingleOrDefault();
        }

        public IList<Request> GetAll()
        {
            return _session.Query<Request>().ToList();
        }

    }
}
