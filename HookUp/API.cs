using System;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Json;
using System.Threading.Tasks;
using System.Diagnostics;
using Plugin.Connectivity;
using Newtonsoft.Json;

namespace HookUp
{
    public class API
    {
        public static string appRoute = "https://murmuring-bayou-59523.herokuapp.com";
        public static string authenticationRoute = appRoute + "/authenticate";
        public static string registerRoute = appRoute + "/register";
        public static string tripRoute = appRoute + "/api/v1/trips";
        public static string peopleRoute = appRoute + "/api/v1/people";
        public static string requestFailedError = "{\"success\": false, message: \"Request failed.\"}";

        private HttpClient _client = new HttpClient();

        public API()
        {
            
        }

        public async Task<ServerResponse> GET(string route, string parameters)
        {
            var res = await _client.GetAsync(new Uri(route));

            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ServerResponse>(content);
            }
            else
            {
                return new ServerResponse {error=true, message="API call failed."};
            }
        }

        public async Task<ServerTripResponse> getTrips(string route, string parameters)
        {
            var res = await _client.GetAsync(new Uri(route));

            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                Debug.WriteLine(content);
                return JsonConvert.DeserializeObject<ServerTripResponse>(content);
            }
            else
            {
                return new ServerTripResponse { error = true, message = "API call failed." };
            }
        }

        public async Task<ServerUserResponse> getUsers(string route, string parameters)
        {
            var res = await _client.GetAsync(new Uri(route));

            if (res.IsSuccessStatusCode)
            {
                var content = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ServerUserResponse>(content);
            }
            else
            {
                return new ServerUserResponse { error = true, message = "API call failed." };
            }
        }

        public async Task<ServerResponse> POST(string route, object parameters)
        {
            // RestUrl = http://developer.xamarin.com:8081/api/todoitems/
            var uri = new Uri(route);
            var json = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            HttpResponseMessage res = await _client.PostAsync(uri, content);

            if (res.IsSuccessStatusCode)
            {
                var resContent = await res.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ServerResponse>(resContent);
            }
            else
            {
                return new ServerResponse { error = true, message = "API call failed." };
            }
        }

        public async Task<ServerTripResponse> createTrip(object parameters)
        {
            var json = JsonConvert.SerializeObject(parameters);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await _client.PostAsync(new Uri(tripRoute), content);

            if (res.IsSuccessStatusCode)
            {
                var resContent = await res.Content.ReadAsStringAsync();
                Debug.WriteLine(resContent);
                return JsonConvert.DeserializeObject<ServerTripResponse>(resContent);
            }
            else
            {
                return new ServerTripResponse { error = true, message = "API call failed." };
            }
        }

        /* */
        //private async Task<ServerResponse> _PUT(string route, object parameters)
        //{
            
        //}

        //private async Task<ServerResponse> DELETE(string route, object parameters)
        //{

        //}

        public class AuthenticationObject
        {
            public string email;
            public string password;
        }

        public async Task<AuthResponse> Authenticate(string email, string password)
        {
            AuthenticationObject authentication = new AuthenticationObject { email = email, password = password };
            var json = JsonConvert.SerializeObject(authentication);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await _client.PostAsync(new Uri(authenticationRoute), content);

            if (res.IsSuccessStatusCode)
            {
                var resContent = await res.Content.ReadAsStringAsync();
                Debug.WriteLine(resContent);
                return JsonConvert.DeserializeObject<AuthResponse>(resContent);
            }
            else
            {
                return new AuthResponse { error = true, message = "API call failed." };
            }
        }

        public async Task<AuthResponse> Register(User user)
        {
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = await _client.PostAsync(new Uri(registerRoute), content);

            if (res.IsSuccessStatusCode)
            {
                var resContent = await res.Content.ReadAsStringAsync();
                Debug.WriteLine(resContent);
                return JsonConvert.DeserializeObject<AuthResponse>(resContent);
            }
            else
            {
                return new AuthResponse { error = true, message = "Register failed." };
            }
        }
    }
}
