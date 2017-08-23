using LibraryProject.Interfaces;

namespace LibraryProject.Models
{
    public class Book : PrintEdition, IBookAble
    {
        public string Author { get; set; }
        public string Publisher { get; set; }
    }
}