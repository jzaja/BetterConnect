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
        public static async Task<IList<User>> GetUserAsync(string username)
        {
            string path = "https://localhost:44355/api/auth/getAll";

            IList<User> user = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                Trace.WriteLine("USPJEH");
                user = await response.Content.ReadAsAsync<IList<User>>();
            } else
            {
                Trace.WriteLine("NEUSPJEH");
            }

            return user;
        }

    }
}
