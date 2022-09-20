using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Domain.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByEmail(string email);
        bool CheckPassword(string email, byte[] hash);
        void SetGuid(Guid id, int userId);
        User? FindUserByGUID(Guid guid);
        bool IsEmailFree(string email);
    }
}
