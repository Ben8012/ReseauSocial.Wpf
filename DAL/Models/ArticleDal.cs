﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ArticleDal
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public bool CommentOk { get; set; }

        public bool OnLigne { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public StatusArticleEnum StatusArticle { get; set; }

    }
}
