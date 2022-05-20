using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BuilderDesignPattern
{
    public class HtmlElement
    {
        public string Name;
        private readonly string _text;
        public readonly List<HtmlElement> Elements = new List<HtmlElement>();
        private const int IndentSize = 2;

        public HtmlElement()
        {
            
        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            _text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int ident)
        {
            var stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine($"{CreateIndentation(ident)}<{Name}");
            if (!string.IsNullOrWhiteSpace(_text))
            {
                stringBuilder.Append(CreateIndentation(ident + 1));
                stringBuilder.AppendLine(_text);
            }

            foreach (var element in Elements)
            {
                stringBuilder.Append(element.ToStringImpl(ident + 1));
            }
            stringBuilder.AppendLine($"{CreateIndentation(ident)}</{Name}");
            return stringBuilder.ToString();
        }

        private string CreateIndentation(int ident)
        {
            return new string(' ', IndentSize * ident);
        }
        
        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string _rootName;
        private HtmlElement _root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            _rootName = rootName;
            _root.Name = rootName;
        }

        public void AddChild(string childName, string childText)
        {
            var element = new HtmlElement(childName, childText);
            _root.Elements.Add(element);
        }

        public override string ToString()
        {
            return _root.ToString();
        }

        public void Clear()
        {
            _root = new HtmlElement {Name = _rootName};
        }
    }
    
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