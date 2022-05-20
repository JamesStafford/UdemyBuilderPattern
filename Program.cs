using static System.Console;

namespace BuilderDesignPattern
{
    public static class Program
    {
        private static void Main()
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            WriteLine(builder.ToString());
        }
    }
}