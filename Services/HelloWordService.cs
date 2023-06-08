
namespace webapi.Services
{
    public class HelloWordService:IHelloWorldService
    {
        public string GetHelloWorld()
        {
            return "hello world";
        }
    }

    public interface IHelloWorldService
    {
        string GetHelloWorld();
    }

    
}