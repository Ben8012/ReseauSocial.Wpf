using BLL.Interfaces;
using BLL.Models;
using ReseauSocial.Wpf.Models;
using ReseauSocial.Wpf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReseauSocial.Wpf.Mappers
{
    internal static class MappersWpf
    {
        internal static UserWpf UserBllToUserWpf(this UserBll u)
        {
            return new UserWpf
            {
                Id = u.Id,
                LastName = u.LastName,
                FirstName = u.FirstName,
                IsAdmin = u.IsAdmin,
                Status = u.Status,
                Token = u.Token,
                Email = u.Email
            };
        }

        internal static ArticleWpf ArticleBllToArticleWpf(this ArticleBll article)
        {
            return new ArticleWpf
            {
                Id = article.Id,
                Title = article.Title,
                Content = article.Content,
                CommentOk = article.CommentOk,
                OnLigne = article.OnLigne,
                UserId = article.UserId,
                Date = article.Date,
                StatusArticle = (StatusArticleEnum)article.StatusArticle

            };
        }
    }
}
