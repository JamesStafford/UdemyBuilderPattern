using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace BuilderDesignPattern
{
    public class HtmlElement
    {
        public string Name, Text;
        public List<HtmlElement> Elements = new List<HtmlElement>();
        private const int indentSize = 2;

        public HtmlElement()
        {
            
        }

        public HtmlElement(string name, string text)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Text = text ?? throw new ArgumentNullException(nameof(text));
        }

        private string ToStringImpl(int ident)
        {
            var stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine($"{CreateIndentation(ident)}<{Name}");
            if (!string.IsNullOrWhiteSpace(Text))
            {
                stringBuilder.Append(CreateIndentation(ident + 1));
                stringBuilder.AppendLine(Text);
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
            return new string(' ', indentSize * ident);
        }
        
        public override string ToString()
        {
            return ToStringImpl(0);
        }
    }

    public class HtmlBuilder
    {
        private readonly string _rootName;
        private HtmlElement root = new HtmlElement();

        public HtmlBuilder(string rootName)
        {
            _rootName = rootName;
            root.Name = rootName;
        }

        public void AddChild(string childName, string childText)
        {
            var element = new HtmlElement(childName, childText);
            root.Elements.Add(element);
        }

        public override string ToString()
        {
            return root.ToString();
        }

        public void Clear()
        {
            root = new HtmlElement {Name = _rootName};
        }
    }
    
    public static class Program
    {
        private static void Main(string[] args)
        {
            var builder = new HtmlBuilder("ul");
            builder.AddChild("li", "hello");
            builder.AddChild("li", "world");
            WriteLine(builder.ToString());
        }
    }
}