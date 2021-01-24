﻿using BetterConnectOO.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BetterConnectOO.API
{
    public class APIManager
    {
        static HttpClient client = new HttpClient();
        public static async Task<IList<User>> GetAllUsers()
        {
            string path = APIConstants.AuthBaseURL + "/getAllUsers";

            IList<User> users = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                users = await response.Content.ReadAsAsync<IList<User>>();
            }

            return users;
        }

        public static async Task<User> RegisterNewUser(string username, string password, string phoneNumber)
        {
            string path = APIConstants.AuthBaseURL + "/register";

            HttpResponseMessage response = await client.PostAsJsonAsync(path, new RegisterUserDTO { Username = username, Password = password, PhoneNumber = phoneNumber });
            response.EnsureSuccessStatusCode();

            User user = await response.Content.ReadAsAsync<User>();
            return user;
        }

        public static async Task<User> LoginUser(string username, string password)
        {
            string path = APIConstants.AuthBaseURL + "/login";

            HttpResponseMessage response = await client.PostAsJsonAsync(path, new LoginUserDTO { Username = username, Password = password });
            response.EnsureSuccessStatusCode();

            User user = await response.Content.ReadAsAsync<User>();
            return user;

        }

        public static Task<User> AddInterest(string interestName, int userId)
        {
            string path = APIConstants.UsersBaseURL + "/addInterest";
            return ManageInterest(path, interestName, userId);
        }

        public static Task<User> RemoveInterest(string interestName, int userId)
        {
            string path = APIConstants.UsersBaseURL + "/removeInterest";
            return ManageInterest(path, interestName, userId);
        }

        private static async Task<User> ManageInterest(string path, string interestName, int userId)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync(path, new InterestUpdateDTO { InterestName = interestName, UserId = userId });
            User user = await response.Content.ReadAsAsync<User>();
            return user;
        }

        public static async Task<Request> SendRequest(int senderId, int receiverId)
        {
            string path = APIConstants.RequestBaseURL + "/sendRequest";

            HttpResponseMessage response = await client.PostAsJsonAsync(path, new SendRequestDTO { SenderId = senderId, ReceiverId = receiverId });
            Request sentRequest = await response.Content.ReadAsAsync<Request>();
            return sentRequest;
        }

        public static Task<IList<Request>> GetSentRequests(int senderId)
        {
            string path = APIConstants.RequestBaseURL + "/getSent/" + senderId.ToString();
            return GetRequests(path, senderId);
        }

        public static Task<IList<Request>> GetReceivedRequests(int receiverId)
        {
            string path = APIConstants.RequestBaseURL + "/getReceived/" + receiverId.ToString();
            return GetRequests(path, receiverId);
        }

        private static async Task<IList<Request>> GetRequests(string path, int userId)
        {
            HttpResponseMessage response = await client.GetAsync(path);
            IList<Request> requests = await response.Content.ReadAsAsync<IList<Request>>();
            return requests;
        }

    }
}
