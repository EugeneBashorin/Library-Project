using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace LibraryProject.Extention_Classes
{
    public static class MagazineExtention
    {
        private static string writePath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/magazines.txt";
        private static string writeXmlPath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/magazines.xml";

        public static void GetTxtList(this List<Magazine> list)
        {
            StringBuilder result = new StringBuilder(130);

            if (list.Count > 0)
            {
                foreach (Magazine item in list)
                {
                    result.AppendLine($"Name: {item.Name} Author: {item.Category} Publisher: {item.Publisher} Price: {item.Price.ToString()}");
                }
            }

            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(result);
            }
        }

        public static void GetXmlList(this List<Magazine> xmlMagazinesList)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Magazine>));

            using (FileStream fs = new FileStream(writeXmlPath, FileMode.Create))
            {
                xs.Serialize(fs, xmlMagazinesList);
            }
        }
    }
}