using System;
using System.Xml;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            App app = new App();
            app.Start();
            Console.ReadLine();

            ReadConfiguration();
        }
        private static void ReadConfiguration()
        {
            XmlDocument configDoc = new XmlDocument();
            configDoc.Load(@"C:\Users\Benjamin Curovic\source\repos\Mandatory-Assignment\Mandatory-Assignment\ServerConfiguration.txt");
           
            XmlNode nameNode = configDoc.DocumentElement.SelectSingleNode("Name");
            if (nameNode != null)
            {
                String nameStr = nameNode.InnerText.Trim();

                Console.WriteLine("History is a set of lies agreed upon. -" + nameStr);
            }

        }
    }
}
