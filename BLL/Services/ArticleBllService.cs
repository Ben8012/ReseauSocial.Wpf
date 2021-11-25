using BLL.Interfaces;
using BLL.Models;
using DAL.Interfaces;
using BLL.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ArticleBllService : IArticleBll
    {
        private readonly IArticleDal _articleDal;

        public ArticleBllService(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public void BlockArticle(int articleId, int AdminId, string message)
        {
            _articleDal.BlockArticle(articleId, AdminId, message);
        }



        public IEnumerable<ArticleBll> GetAllArticle()
        {
            return _articleDal.GetAllArticle().Select(a => a.ArticleDalToArticleBll());
        }

        public IEnumerable<ArticleBll> GetArticleByUserId(int userId)
        {
            return _articleDal.GetArticleByUserId(userId).Select(a => a.ArticleDalToArticleBll());
        }

        public ArticleBll GetArticleById(int articleId)
        {
            return _articleDal.GetArticleById(articleId).ArticleDalToArticleBll();
        }

        public bool IsArticleBlock(int articleId)
        {
            return _articleDal.IsArticleBlock( articleId);
        }

        public bool IsSignalArticle(int articleId)
        {
            return _articleDal.IsSignalArticle(articleId);
        }

        public void UnBlockArticleAdmin(int articleId, int AdminId)
        {
            _articleDal.UnBlockArticleAdmin(articleId, AdminId);
        }

        public bool IsSignalByUser(int articleId, int userId)
        {
            return _articleDal.IsSignalByUser(articleId, userId);
        }

        public void UnSignalArticleAdmin(int articleId, int userId)
        {
            _articleDal.UnSignalArticleAdmin(articleId, userId);
        }
    }
}
