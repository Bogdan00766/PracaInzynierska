using PracaInzynierska.Domain.Models;

namespace PracaInzynierska.Domain.IRepositories
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
