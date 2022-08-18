using PracaInżynierska.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Application.Interfaces
{
    public interface IUserService
    {
        UserDto Login(string username, string password);
        void Logout(Guid guid);
        UserDto Register(string name, string lastName, string password, string email);
        void SetGuid(Guid id, int userId);
        bool IsLogged(Guid guid);
        UserDto FindByGuid(Guid guid);
    }
}
