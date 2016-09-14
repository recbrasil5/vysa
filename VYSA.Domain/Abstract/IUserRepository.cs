using System;
using VYSA.Domain.Entities;
using System.Linq;
using System.Collections.Generic;

namespace VYSA.Domain.Abstract
{
    public interface IUserRepository
    {
        void Delete(User user);
        User GetUser(int id);
        User GetUser(string email);
        User GetUser(string email, string passwordHash);
        IEnumerable<User> GetUsersWithRoles();
        bool EmailExists(string email);
        string ResetPassword(string email);
        User GetUserByEmail(string email);
        void Save(User user);
        IQueryable<User> Users { get; }
        IQueryable<User> ActiveUsers { get; }
    }
}
