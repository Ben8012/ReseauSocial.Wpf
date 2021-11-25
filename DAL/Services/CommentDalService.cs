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
    public class CommentDalService : AbstracService, ICommentDal
    {
        public IEnumerable<CommentDal> GetByArticleId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
                using (HttpResponseMessage httpResponseMessage = client.GetAsync("Comment/GetByArticleId/" + id).Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<CommentDal>>(json);
                }
            }
        }

        public int CountByArticleId(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                setBaseAdress(client);
                using (HttpResponseMessage httpResponseMessage = client.GetAsync("Comment/CountByArticleId/" + id).Result)
                {
                    httpResponseMessage.EnsureSuccessStatusCode();
                    string json = httpResponseMessage.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<int>(json);
                }
            }
        }
    }
}
