using System;
using VYSA.Domain.Entities;
using System.Linq;

namespace VYSA.Domain.Abstract
{
    public interface IRoleRepository
    {
        void Delete(Role role);
        Role GetRole(int Id);
        Role GetRole(string roleName);
        void Save(Role role);
        IQueryable<Role> Roles { get; }
    }
}
