using ProjectDatabase.Domain;
using ProjectDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Services
{
    public class UserService
    {
        private IUserRepository _userRepo;
        private IInterestRepository _interestRepository;

        public UserService(IUserRepository userRepo, IInterestRepository interestRepository)
        {
            _userRepo = userRepo;
            _interestRepository = interestRepository;
        }

        public IList<User> GetAllUsers()
        {
            return _userRepo.GetAll();
        }

        public User AddInterest(int userId, string interestName)
        {
            User user = (User)_userRepo.Get(userId);
            Interest interest = _interestRepository.GetByName(interestName);

            if (user.Interests.Contains(interest))
            {
                return null;
            }

            if (interest == null)
            {
                Interest newInterest = new Interest { Name = interestName };

                var saved = _interestRepository.Save(newInterest);
                saved.AddUser(user);
                
                _interestRepository.Update(saved);
            } else
            {
                interest.AddUser(user);
                _interestRepository.Update(interest);
            }

            return user;
        }

        public User RemoveInterest(int userId, string interestName)
        {
            User user = (User)_userRepo.Get(userId);
            Interest interest = _interestRepository.GetByName(interestName);

            if (interest == null)
            {
                // something went terribly wrong if i try to remove my own non-existing interest
                return null;
            }

            user.RemoveInterest(interest);

            _interestRepository.Update(interest);
            return user;
        }

        public User DeleteUser(int adminId, int userId)
        {
            // only admin can delete user from system
            var admin = _userRepo.Get(adminId) as Admin;
            if (admin == null)
            {
                return null;
            }

            User user = _userRepo.GetUser(userId);
            return _userRepo.Delete(user);
        }

    }
}
