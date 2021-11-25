using BLL.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Mappers;
using BLL.Interfaces;

namespace BLL.Services
{
    public class UserBllService : IUserBll
    {
        private readonly IUserDal _userDalService;

        public UserBllService(IUserDal userDalService)
        {
            _userDalService = userDalService;
        }


        public void BlockedStatusAdmin(int ChangedUserId, int EditorUserId, string token)
        {
            _userDalService.BlockedStatusAdmin(ChangedUserId, EditorUserId, token);
        }

        public void DeleteStatusAdmin(int ChangedUserId, int EditorUserId, string token)
        {
            _userDalService.DeleteStatusAdmin(ChangedUserId, EditorUserId, token);
        }

        public void UnBlockedStatusAdmin(int ChangedUserId, int EditorUserId, string token)
        {
            _userDalService.UnBlockedStatusAdmin(ChangedUserId, EditorUserId, token);
        }
        public void ReactivateStatusAdmin(int ChangedUserId, int EditorUserId, string token)
        {
            _userDalService.ReactivateStatusAdmin(ChangedUserId, EditorUserId, token);
        }

        public bool EmailExists(string email)
        {
            return _userDalService.EmailExists(email);
        }

        public UserBll Login(string email, string passwd)
        {
            return _userDalService.Login(email, passwd).DalUserToBllUser();
        }

        public StatusBll GetStatus(int userId, string token)
        {
           return _userDalService.GetStatus(userId, token).DalStatusToBllStatus();
        }

        public UserBll GetUser(int userId, string token)
        {
            return _userDalService.GetUser(userId, token).DalUserToBllUser();
        }

        public IEnumerable<UserBll> GetAllUsers( string token)
        {
            return _userDalService.GetAllUsers(token).Select(u => u.DalUserToBllUser());
        }
    }
}
