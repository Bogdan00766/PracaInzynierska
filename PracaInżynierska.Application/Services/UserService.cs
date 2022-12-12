using AutoMapper;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Application.Interfaces;
using PracaInzynierska.Domain.IRepositories;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public bool ChangePassword(int id, string newpassword)
        {
            //if(email == null) throw new ArgumentNullException("Email cannot be null");
            //if (newpassword == null) throw new ArgumentNullException("New password cannot be null");
            //var user = _userRepository.FindByEmail(email);
            //if (user == null) throw new Exception("User not found");
            throw new NotImplementedException();
        }

        public UserDto FindByGuid(Guid guid)
        {
            return _mapper.Map<UserDto>(_userRepository.FindUserByGUID(guid));
        }

        public bool ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public bool IsLogged(Guid guid)
        {
            var user = _userRepository.FindUserByGUID(guid);
            if (user == null) return false;
            return true;
        }

        public UserDto Login(string email, string password)
        {
            if (email == null) throw new Exception("Email cannot be null");
            if (password == null) throw new Exception("Password cannot be null");
            var user = _userRepository.FindByEmail(email);
            if (user == null) throw new Exception("User not found");

            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(email + password));
            }
            if (_userRepository.CheckPassword(email, hash))
            {
                _userRepository.SaveAsync();
                return _mapper.Map<UserDto>(user);
            }
            else throw new Exception("Wrong password");
        }

        public void Logout(Guid guid)
        {
            var user = _userRepository.FindUserByGUID(guid);
            if (user == null) throw new Exception("User is not logged in");
            user.AutoLoginGUID = Guid.Empty.ToString();
            user.AutoLoginGUIDExpires = DateTime.MinValue;

            _userRepository.SaveAsync();
        }

        public UserDto Register(string name, string password, string email)
        {
            if (name == null) throw new Exception("Name cannot be null");
            if (password == null) throw new Exception("Password, cannot be null");
            if (email == null) throw new Exception("Email cannot be null");

            if(!_userRepository.IsEmailFree(email)) throw new Exception("Email is already in use");

            password = email + password;

            byte[] hash;
            using (SHA256 sha256 = SHA256.Create())
            {
                hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
            User user = new User()
            {
                Name = name,
                Password = hash,
                EMail = email,
            };

            var usr = _userRepository.Create(user);
            _userRepository.SaveAsync();

            return _mapper.Map<UserDto>(usr);
        }

        public void SetGuid(Guid id, int userId)
        {
            _userRepository.SetGuid(id, userId);
            _userRepository.SaveAsync();
        }
    }
}
