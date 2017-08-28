using LibraryProject.Models;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Extention_Classes
{
    public static class BookExtention
    {
        public static string GetListToString(this List<Book> list)
        {
            StringBuilder result = new StringBuilder(130);

            if (list.Count > 0)
            {
                foreach (Book item in list)
                {
                    result.AppendLine($"Name: {item.Name} Author: {item.Author} Publisher: {item.Publisher} Price: {item.Price.ToString()}");
                }
            }
            return result.ToString();
        }
    }
}