using BetterConnectOO.Models;
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
            string path = APIConstants.AuthBaseURL + "/getAll";

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

    }
}
