using LibraryProject.Models;
using System.Collections.Generic;
using System.Text;

namespace LibraryProject.Extention_Classes
{
    public static class NewsPaperExtention
    {
        public static string GetListToString(this List<NewsPaper> list)
        {
            StringBuilder result = new StringBuilder(130);

            if (list.Count > 0)
            {
                foreach (NewsPaper item in list)
                {
                    result.AppendLine($"Name: {item.Name} Author: {item.Category} Publisher: {item.Publisher} Price: {item.Price.ToString()}");
                }
            }
            return result.ToString();
        }
    }
}