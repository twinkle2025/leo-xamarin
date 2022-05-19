using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Leo.Models;
using Leo.Models.APITemplate;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace Leo.Services
{
    class Accounts
    {
        public static async Task<APIResponse> SignIn(Login logininfo)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(AppConfig.authAPI);

            string jsonData = JsonConvert.SerializeObject(logininfo);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = new HttpResponseMessage();
            string error = "";
            LoginSuccess userInfo;
            int status;
            string result;

            try
            {
                response = await client.PostAsync("api/Account/authenticate", content);
                result = await response.Content.ReadAsStringAsync();
                status = (int)response.StatusCode;
            }
            catch (Exception)
            {
                return null;
            }

            if (status == 500)
                error = result;
            else if (status == 401)
                error = "Wrong credential";
            else if (status == 400)
                error = "Invalid Email";
            else if(status == 200)
            {
                userInfo = JsonConvert.DeserializeObject<LoginSuccess>(result);
                App.LoggedUser = userInfo;
            }

            return new APIResponse { Status = status, Error = error };
        }

        public static async Task<bool> GetToken()
        {
            string oauthToken;
            try
            {
                oauthToken = await SecureStorage.GetAsync(AppConfig.UserTokenKey);
            }
            catch
            {
                // Possible that device doesn't support secure storage on device.
                return false;
            }

            if (string.IsNullOrWhiteSpace(oauthToken))
            {
                return false;
            }
            else
            {
                App.LoggedUser = new LoginSuccess
                {
                    Token = oauthToken
                };
                return true;
            }
        }
    }
}
