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
    public class ArticleDalService : AbstracService, IArticleDal
    {
        public void BlockArticle(int articleId, int adminId, string messageWhyBlocked)
        {

            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                string jsonBody = JsonConvert.SerializeObject(
                    new ArticleBlocked {
                        ArticleId = articleId,
                        AdminId = adminId,
                        Message = messageWhyBlocked 
                    });
                HttpContent content = new StringContent(jsonBody, Encoding.Default, "application/json");

                using (HttpResponseMessage message = client.PostAsync("Article/BlockArticleAdmin", content).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public IEnumerable<ArticleDal> GetAllArticle()
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/GetAllArticle").Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<ArticleDal>>(json);
                }
            }
        }

        public ArticleDal GetArticleById(int articleId)
        {

            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
               
                using (HttpResponseMessage message = client.GetAsync("Article/GetArticleById/" + articleId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<ArticleDal>(json);
                }
            }
        }

        public IEnumerable<ArticleDal> GetArticleByUserId(int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/GetArticleByUserId/" + userId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<ArticleDal>>(json);
                }
            }
        }

        public bool IsArticleBlock(int articleId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/IsArticleBlock/" + articleId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(json);
                }
            }
           
        }

        public bool IsSignalArticle(int articleId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/IsSignalArticle/" + articleId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(json);
                }
            }
        }

        public bool IsSignalByUser(int articleId, int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/IsSignalByUser/" + articleId +"/"+ userId).Result)
                {
                    if (!message.IsSuccessStatusCode)
                        throw new HttpRequestException();

                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<bool>(json);
                }
            }
        }

        public void UnBlockArticleAdmin(int articleId, int AdminId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/UnBlockArticleAdmin/"+articleId+"/"+ AdminId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }

        public void UnSignalArticleAdmin(int articleId, int userId)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);

                using (HttpResponseMessage message = client.GetAsync("Article/UnSignalArticleAdmin/" + articleId + "/" + userId).Result)
                {
                    message.EnsureSuccessStatusCode();
                }
            }
        }
    }
}
