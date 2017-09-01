using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LibraryProject.Extention_Classes
{
    public static class BookExtention
    {
        private static string writePath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/books.txt";
        private static string writeXmlPath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/books.xml";

        public static void GetTxtList(this List<Book> list)
        {
            StringBuilder result = new StringBuilder(130);

            if (list.Count > 0)
            {
                foreach (Book item in list)
                {
                    result.AppendLine($"Name: {item.Name} Author: {item.Author} Publisher: {item.Publisher} Price: {item.Price.ToString()}");
                }
            }

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(result);
            }
        }

        public static void GetXmlList(this List<Book> xmlBooksList)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Book>));

            using (FileStream fs = new FileStream(writeXmlPath, FileMode.Create))
            {
                xs.Serialize(fs, xmlBooksList);
            }
        }
    }
}