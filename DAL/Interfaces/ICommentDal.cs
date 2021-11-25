﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ICommentDal
    {
        IEnumerable<CommentDal> GetByArticleId(int id);
   
        int CountByArticleId(int id);
      
    }
}
