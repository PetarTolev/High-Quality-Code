namespace DOMBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Element
    {
        private ICollection<Element> children;
        private string name;

        public Element(string name, params Element[] children)
        {
            this.children = children.ToList();
            this.name = name;
        }

        public void Add(Element element)
        {
            if (this.children.Contains(element))
            {
                throw new ArgumentException("Child already exist!");
            }

            this.children.Add(element);
        }

        public void Remove(Element element)
        {
            if (!this.children.Contains(element))
            {
                throw new ArgumentException("Child does not exist!");
            }

            this.children.Remove(element);
        }

        public string Display(int level = 0)
        {
            var result = new StringBuilder();
            result.AppendLine($"{new string(' ', level)}<{this.name}>");

            foreach (var child in this.children)
            {
                result.AppendLine(child.Display(level + 3));
            }

            result.AppendLine($"{new string(' ', level)}</{this.name}>");

            return result.ToString().TrimEnd();
        }
    }
}