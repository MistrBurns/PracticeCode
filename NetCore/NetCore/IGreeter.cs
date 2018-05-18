namespace NetCore
{
    public interface IGreeter
    {
        string GetMessage();
    }

    public class Greeter : IGreeter
    {
        public string GetMessage()
        {
            return "Greetings";
        }
    }
}