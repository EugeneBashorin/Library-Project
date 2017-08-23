using LibraryProject.Interfaces;

namespace LibraryProject.Models
{
    public class Magazine : PrintEdition, IMagazineAble
    {
        public string Category { get; set; }
    }
}