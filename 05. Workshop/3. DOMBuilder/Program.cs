namespace DOMBuilder
{
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            Element html = 
                new Element("html", 
                    new Element("head"),
                    new Element("body", 
                        new Element("section", 
                            new Element("h2"),
                            new Element("p"),
                            new Element("span")),
                        new Element("footer")));

            File.WriteAllText("../../../index.html", html.Display());
        }
    }
}
