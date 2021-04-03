using AutoMapper;
using DBModel.Interfaces;
using Pomona.Interfaces;
using Pomona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pomona.Services
{

    public class LoginService : ILoginService
    {
        private readonly ILoginRepository loginRepository;
        private readonly IMapper mapper;
        public LoginService(ILoginRepository loginRepository, IMapper mapper)
        {
            this.mapper= mapper;
            this.loginRepository = loginRepository;
        }
        public void AddUser(User user)
        {
            var userDB = mapper.Map<DBModel.Models.User>(user);
            loginRepository.Add(userDB);
        }

        public void DeleteUser(User user)
        {
            var userDB = mapper.Map<DBModel.Models.User>(user);
            loginRepository.Delete(userDB);
        }

        public List<User> GetUsers()
        {
            var users = loginRepository.GetUsers();
            var usersDto = mapper.Map<IEnumerable<Models.User>>(users);
            return usersDto.ToList();
        }

        public void SaveChanges()
        {
          loginRepository.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var userDB = mapper.Map<DBModel.Models.User>(user);
            loginRepository.Update(userDB);
        }
    }
}