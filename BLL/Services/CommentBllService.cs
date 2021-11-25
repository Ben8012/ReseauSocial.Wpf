using BLL.Interfaces;
using BLL.Mappers;
using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class CommentBllService : ICommentBll
    {
        private readonly ICommentDal _commentDal;

        public CommentBllService(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public int CountByArticleId(int id)
        {
            return _commentDal.CountByArticleId(id);
        }



        public IEnumerable<CommentBll> GetByArticleId(int id)
        {
            return _commentDal.GetByArticleId(id).Select(c => c.CommentDalToCommentBll());
        }

    
    }
}
