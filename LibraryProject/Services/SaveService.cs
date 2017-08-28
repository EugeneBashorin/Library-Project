using LibraryProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace LibraryProject.Service
{
    public static class SaveService
    {
        private static string writePath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/txtList.txt";
        private static string writeXmlPath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/xmlList.xml";

        public static void GetTxtList(string textData)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(textData);
            }
        }

        public static void GetXmlList(List<Book> xmlBookList)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Book>));

            using (FileStream fs = new FileStream(writeXmlPath, FileMode.Create))
            {
                xs.Serialize(fs, xmlBookList);
            }
        }
    }
}