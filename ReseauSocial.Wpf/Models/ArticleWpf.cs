using BLL.Models;
using ReseauSocial.Wpf.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReseauSocial.Wpf.Models
{
    public class ArticleWpf
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public bool CommentOk { get; set; }

        public bool OnLigne { get; set; }

        public int UserId { get; set; }

        public UserBll Auteur { get; set; }

        public StatusArticleEnum StatusArticle { get; set; }

        public DateTime Date { get; set; }
    }
}
