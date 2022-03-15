using System.Collections.Generic;
using System.Linq;
using AuthHorn.Models;

namespace AuthHorn.Repositories
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();

            users.Add(new User { Id = 1, UserName = "cristiano", Password = "cristiano", Role = "manager" });
            users.Add(new User { Id = 2, UserName = "jessica", Password = "jessica", Role = "employee" });

            return users.FirstOrDefault(x => x.UserName == username && x.Password == password);
        }
    }
}