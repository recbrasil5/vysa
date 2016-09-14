using System;
using VYSA.Domain.Concrete;
using VYSA.Domain.Entities;

namespace VYSA.Domain.Abstract
{
    public interface IUnitOfWork
    {
        EfUserRepository UserRepository { get; }
        EfRoleRepository RoleRepository { get; }
        void Save();
        void Dispose();
    }
}
