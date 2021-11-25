using BLL.Models;
using DAL.Models;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserBll
    {
        void BlockedStatusAdmin(int ChangedUserId, int EditorUserId, string token);
        void DeleteStatusAdmin(int ChangedUserId, int EditorUserId, string token);

        void UnBlockedStatusAdmin(int ChangedUserId, int EditorUserId, string token);
        void ReactivateStatusAdmin(int ChangedUserId, int EditorUserId, string token);
        bool EmailExists(string email);
        UserBll Login(string email, string passwd);
        StatusBll GetStatus(int userId, string token);
        UserBll GetUser(int userId, string token);
        IEnumerable<UserBll> GetAllUsers(string token);
    }
}