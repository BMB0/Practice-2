using System;
using System.Collections.Generic;

namespace Logic
{
    public class UserManager : IUserManager
    {
        public List<User> Users { get; set; }

        public UserManager()
        {
            Users = new List<User>
            {
                new User() { Name = "Bruno", Ci = 12345678 },
                new User() { Name = "Andres", Ci = 87654321 }
            };
        }
        public List<User> GetUsers()
        {
            return Users;
        }
        public User PostUser(User user)
        {
            Users.Add(user);
            return user;
        }
        public User PutUser(User user, int ci)
        {
            var userToUpdate = Users.Find(u => u.Ci == ci);
            if(userToUpdate != null)
            {
                userToUpdate.Name = user.Name;
                userToUpdate.Ci = user.Ci;
            }
            return userToUpdate;
        }
        public User DeleteUser(User user)
        {
            var userToDelete = Users.Find(u => u.Ci == user.Ci);
            Users.Remove(userToDelete);
            return userToDelete;
        }
    }
}
