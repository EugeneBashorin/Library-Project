using LibraryProject.Interfaces;

namespace LibraryProject.Models
{
    public class NewsPaper : PrintEdition, INewspaperAble
    {
        public string Category { get; set; }
    }
}