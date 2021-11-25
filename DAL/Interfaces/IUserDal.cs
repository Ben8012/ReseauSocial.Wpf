using DAL.Models;
using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IUserDal
    {
        void BlockedStatusAdmin(int ChangedUserId, int EditorUserId, string token);
        void DeleteStatusAdmin(int ChangedUserId, int EditorUserId, string token);
        void UnBlockedStatusAdmin(int ChangedUserId, int EditorUserId, string token);
        void ReactivateStatusAdmin(int ChangedUserId, int EditorUserId, string token);
        bool EmailExists(string email);
        UserDal Login(string email, string passwd);
        StatusDal GetStatus(int userId, string token);
        UserDal GetUser(int userId, string token);
        IEnumerable<UserDal> GetAllUsers(string token);
    }
}