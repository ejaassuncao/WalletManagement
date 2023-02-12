using System;

namespace Domain.Commons.Entity
{
    public class User : EntityBase
    {  
        public string Login { get; set; }
        public string Password { get; set; }

        public User(Guid id, string login, string password) : base(id)
        {
            Login = login;
            Password = password;
        }

        public User(string login, string password) 
        {
            Login = login;
            Password = password;
        }        
    }
}
