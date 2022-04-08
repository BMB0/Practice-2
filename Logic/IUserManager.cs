using System.Collections.Generic;

namespace Logic
{
    public interface IUserManager
    {
        public List<User> GetUsers();
        public User PostUser(User user);
        public User PutUser(User user, int ci);
        public User DeleteUser(User user);

    }
}