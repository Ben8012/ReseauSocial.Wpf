using BLL.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ICommentBll
    {
        IEnumerable<CommentBll> GetByArticleId(int id);
   
        int CountByArticleId(int id);
      
    }
}
