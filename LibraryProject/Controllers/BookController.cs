using LibraryProject.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class BookController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Book> bookList;

            if (Session["Book"] == null)
            {
                bookList = new List<Book>();

            bookList.Add(new Book
            {
                Name = "Head First C#", Author = "A.Stellman,J.Greene", Publisher = "O'Reilly", Price = 540
            } );
            bookList.Add(new Book
            {
                Name = "LINQ Succinctly", Author = "J.Roberts", Publisher = "Syncfusion", Price = 200
            });
            bookList.Add(new Book
            {
                Name = "Java Script Patterns", Author = "S.Stefanov", Publisher = "O'Reilly", Price = 312
            });
            bookList.Add(new Book
            {
                Name = "Head First JS Programming", Author = "E.Freeman,E.Robson", Publisher = "O'Reilly", Price = 330
            });
            bookList.Add(new Book
            {
                Name = "SQL The Complete Reference", Author = "J.Groff,P.Weinberg,A.Oppel", Publisher = "Williams", Price = 158
            });
            bookList.Add(new Book
            {
                Name = "Getting started with ASP.NET 5.0 Web Forms", Author = "N.Gaylord,Ch.Wenz,P.Rastogi,T.Miranda", Publisher = "O'Reilly", Price = 400
            });
            bookList.Add(new Book
            {
                Name = "C# 6.0 Complete Guide", Author = "J. & B.Albahairy", Publisher = "Williams", Price = 499
            });
            bookList.Add(new Book
            {
                Name = "ASP.NET 4.5 in C# and VB", Author = "J.Gaylord", Publisher = "Wrox", Price = 274
            });
            bookList.Add(new Book
            {
                Name = "Head First SQL", Author = "Lynn Beighley", Publisher = "O'Reilly", Price = 299
            });

            bookList.Add(new Book
            {
                Name = "Design Patterns via C#", Author = "A.Shevchyk,A.Kasianov,D.Ohrimenko", Publisher = "ITVDN", Price = 830
            });
            bookList.Add(new Book{Name = "OOP in C#. Succinctly", Author = "S.Rossel", Publisher = "Syncfusion", Price = 830});
                }
            else //if (Session["Book"] != null)
            {
                bookList = (List<Book>)Session["Book"];
            }
            return View(bookList);
        }
    }
}