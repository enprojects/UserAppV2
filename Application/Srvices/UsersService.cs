using Application.Implemintation;

using Modal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Srvices
{
    public class UsersService
    {
        private readonly GenericRepo<User> usersRepository;

        public UsersService()
        {
            usersRepository = new GenericRepo<User>();
        }

        public IEnumerable<User> Get(Func<User,bool> func=null)
        {
            return usersRepository.Get(func);
        }
        public int Edit(User user)
        {
           
            var oldUser = usersRepository.Get(x => x.Id == user.Id).SingleOrDefault();
            if (oldUser != null)
            {
                oldUser.FirstName = user.FirstName;
                oldUser.LastName = user.LastName;
                oldUser.Password = user.Password;
                oldUser.Email = user.Email;
                
                return usersRepository.Update();
            }

            return -1;
        }
        public int Create(User user)
        {
            return usersRepository.Add(user);
        }
        public int Delete(User user)
        {
            var oldUser = usersRepository.Get(x => x.Id == user.Id).SingleOrDefault();
            if (oldUser != null)
            {
                return usersRepository.Remove(oldUser);
            }
            return -1;
        }





    }
}
