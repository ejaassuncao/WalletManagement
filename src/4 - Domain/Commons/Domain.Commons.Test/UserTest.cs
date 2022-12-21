using Domain.Commons.Entity;

namespace Domain.Commons.Test
{
    public class UserTest
    {   
        public static User GetNewInstanceMock()
        {
           return new User("ewa.soft@gmail.com", "123");
        }
    }
}
