using System.Text;
using static System.Console;

namespace BuilderDesignPattern
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            const string hello = "hello";
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<p>");
            stringBuilder.Append(hello);
            stringBuilder.Append("</p>");
            WriteLine(stringBuilder);

            var words = new[] {"hello", "world"};
            stringBuilder.Clear();
            stringBuilder.Append("<ul>");
            foreach (var word in words)
            {
                stringBuilder.AppendFormat("<li>{0}</li>", word);
            }
            stringBuilder.Append("</ul>");
            
            WriteLine(stringBuilder);
        }
    }
}