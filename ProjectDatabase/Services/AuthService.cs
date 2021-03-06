﻿using ProjectDatabase.Domain;
using ProjectDatabase.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDatabase.Services
{
    public class AuthService
    {

        private IUserRepository _userRepo;

        public AuthService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public BasicUser Login(string username, string password)
        {
            BasicUser user = GetByUsername(username);
            if (user == null)
            {
                return null;
            }

            if (user.Password == password)
            {
                return user;
            }

            return null;
        }

        public User Register(string username, string password, string phoneNumber)
        {
            if (_userRepo.ExistsByUsernameOrPhoneNumber(username, phoneNumber))
            {
                return null;
            }

            User newUser = new User { Username = username, Password = password, PhoneNumber = phoneNumber };
            _userRepo.Save(newUser);
            return newUser;
        }

        public Admin RegisterAdmin(string password)
        {
            if (_userRepo.GetByUsername("admin") != null)
            {
                return null;
            }

            Admin admin = new Admin { Username = "admin", Password = password };
            _userRepo.Save(admin);
            return admin;
        }

        private BasicUser GetByUsername(string username)
        {
            if (username == null)
            {
                return null;
            }

            return _userRepo.GetByUsername(username.ToLower());
        }

        private User GetByPhoneNumber(string phoneNumber)
        {
            return _userRepo.GetByPhoneNumber(phoneNumber);
        }

    }
}
