using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IArticleBll
    {
        void BlockArticle(int articleId, int AdminId, string message);
   
        IEnumerable<ArticleBll> GetAllArticle();

        IEnumerable<ArticleBll> GetArticleByUserId(int userId);

        ArticleBll GetArticleById(int articleId);

        bool IsArticleBlock(int articleId);


        bool IsSignalArticle(int articleId);


        void UnBlockArticleAdmin(int articleId, int AdminId);

        bool IsSignalByUser(int articleId, int userId);

        void UnSignalArticleAdmin(int articleId, int userId);
    }
}
