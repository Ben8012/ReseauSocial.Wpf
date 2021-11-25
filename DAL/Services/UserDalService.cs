using DAL.Interfaces;
using DAL.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace DAL.Services
{
    public class UserDalService : AbstracService, IUserDal 
    {

        /*-------------------Post & Put & Delete----------------------------*/
        #region Admin
        public void BlockedStatusAdmin(int ChangedUserId, int EditorUserId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/BlockedStatusAdmin/"+ ChangedUserId +"/"+ EditorUserId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }

        }

        public void DeleteStatusAdmin(int ChangedUserId, int EditorUserId, string token)
        {

            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/DeleteStatusAdmin/" + ChangedUserId + "/" + EditorUserId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }


        public void UnBlockedStatusAdmin(int ChangedUserId, int EditorUserId, string token)
        {

            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/UnBlockedStatusAdmin/" + ChangedUserId + "/" + EditorUserId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void ReactivateStatusAdmin(int ChangedUserId, int EditorUserId, string token)
        {

            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/ReactivateStatusAdmin/" + ChangedUserId + "/" + EditorUserId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }


        #endregion

        public bool EmailExists(string email)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new { email = email });
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("User/register/", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(json);
                }
            }
        }


        public UserDal Login(string email, string passwd)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(new LoginUserDal{ Email = email, Passwd = passwd });
                HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                using (HttpResponseMessage message = client.PostAsync("User/Login", content).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<UserDal>(json);
                }
            }
        }

        
        public StatusDal GetStatus(int userId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken(client, token);

                using (HttpResponseMessage message = client.GetAsync("User/GetStatus/" + userId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<StatusDal>(json);
                }
            }
        }

        #region GetUser
        /*-------------------GetUser----------------------------*/

        public UserDal GetUser(int userId, string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("User/GetUser/" + userId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<UserDal>(json);
                }
            }
        }

        public IEnumerable<UserDal> GetAllUsers( string token)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdresseWithToken( client, token);

                using (HttpResponseMessage message = client.GetAsync("User/GetAllUsers/").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<UserDal>>(json);
                }
            }
        }

        #endregion

    }

}