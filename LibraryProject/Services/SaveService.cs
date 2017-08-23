using System;
using System.IO;

namespace LibraryProject.Service
{
    public class SaveService
    {
        private string writePath = AppDomain.CurrentDomain.BaseDirectory + @"App_Data/booksList.txt";
        public void GetList(string textData)
        {
            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(textData);
            }
        }
    }
}