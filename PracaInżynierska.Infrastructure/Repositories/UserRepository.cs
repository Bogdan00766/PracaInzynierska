using PracaInżynierska.Domain.IRepositories;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(PIDbContext dbContext) : base(dbContext)
        {
        }

        public bool CheckPassword(string email, byte[] hash)
        {
            if (email == null) throw new ArgumentNullException("email cannot be null");
            if (hash == null) throw new ArgumentNullException("hash cannot be null");
            var user = FindByEmail(email);
            if (user == null) throw new Exception("User not found");

            if (ifHashesEqual(user.Password, hash)) return true;
            else return false;
        }

        private bool ifHashesEqual(byte[] hash1, byte[] hash2)
        {
            bool bEqual = false;
            if (hash1.Length == hash2.Length)
            {
                int i = 0;
                while ((i < hash1.Length) && (hash1[i] == hash2[i]))
                {
                    i += 1;
                }
                if (i == hash1.Length)
                {
                    bEqual = true;
                }
            }
            return bEqual;
        }

        public User? FindByEmail(string email)
        {
            return _dbContext.User.Where(x => x.EMail == email).FirstOrDefault();

        }

        public void SetGuid(Guid id, int userId)
        {
            var user = _dbContext.User.Where(x => x.Id == userId).FirstOrDefault();
            user.AutoLoginGUID = id.ToString();
            user.AutoLoginGUIDExpires = DateTime.Now.AddDays(1);
        }

        public User? FindUserByGUID(Guid guid)
        {
            var user = _dbContext.User.Where(x => x.AutoLoginGUID == guid.ToString()).FirstOrDefault();
            if (user != null && user.AutoLoginGUIDExpires >= DateTime.Now.AddDays(1)) return null;
            return user;
        }
    }
}
