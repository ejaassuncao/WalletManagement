namespace Application.Core.Wallat
{
    public class Mappper<T>
    {        
        public static T Parse(object obj)
        {
            return (T)obj;
        }
    }
}