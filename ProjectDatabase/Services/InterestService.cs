using ProjectDatabase.Domain;
using ProjectDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Services
{
    public class InterestService
    {
        private IInterestRepository _interestRepository;

        public InterestService(IInterestRepository interestRepository)
        {
            _interestRepository = interestRepository;
        }

        public IList<Interest> GetAll()
        {
            return _interestRepository.GetAll();
        }

        public ISet<User> GetInterestUsers(string interestName)
        {
            return _interestRepository.GetUsersByInterestName(interestName);
        }

    }
}
