using LibraryProject.Interfaces;
using LibraryProject.Models;
using LibraryProject.Service;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        List<PrintEdition> bookList;
        SaveService saver;
        StringBuilder listData;

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["PrintEdition"] == null)
            {
                bookList = new List<PrintEdition>();

                bookList.Add(new Book
                {
                    Name = "Head First C#", Author = "A.Stellman,J.Greene", Publisher = "O'Reilly", Price = 540
                });
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
                bookList.Add(new Book
                {
                    Name = "OOP in C#. Succinctly", Author = "S.Rossel", Publisher = "Syncfusion", Price = 830
                });

                bookList.Add(new Magazine
                {
                    Name = "MartialMix", Category = "Sport", Price = 16
                });
                bookList.Add(new Magazine
                {
                    Name = "Fashion", Category = "Fashion", Price = 20
                });
                bookList.Add(new Magazine
                {
                    Name = "Forbs", Category = "Economic", Price = 25
                });
                bookList.Add(new Magazine
                {
                    Name = "Geek", Category = "IT", Price = 21
                });
                bookList.Add(new Magazine
                {
                    Name = "Amaizing Wild World", Category = "Nature", Price = 22
                });
                bookList.Add(new Magazine
                {
                    Name = "Braine Scince", Category = "Psychology", Price = 26
                });
                bookList.Add(new Magazine
                {
                    Name = "Car Evo", Category = "Car", Price = 24
                });
                bookList.Add(new Magazine
                {
                    Name = "Robo", Category = "Scince", Price = 32
                });
                bookList.Add(new Magazine
                {
                    Name = "Zadrot", Category = "Games", Price = 16
                });
                bookList.Add(new Magazine
                {
                    Name = "Design & Creative", Category = "Design", Price = 30
                });
                bookList.Add(new NewsPaper
                {
                    Name = "The NewYork Times", Category = "News", Price = 7
                });
                bookList.Add(new NewsPaper
                {
                    Name = "The WallSteet Jornal", Category = "Economy", Price = 7
                });
                bookList.Add(new NewsPaper
                {
                    Name = "Ring", Category = "Sport", Price = 7
                });
                bookList.Add(new NewsPaper
                {
                    Name = "Los Angeles Times", Category = "News", Price = 7
                });
                bookList.Add(new NewsPaper
                {
                    Name = "The Washington Post", Category = "News", Price = 7
                });
                bookList.Add(new NewsPaper
                {
                    Name = "The Times", Category = "News", Price = 1
                });
                bookList.Add(new NewsPaper
                {
                    Name = "The Guardian", Category = "News", Price = 1
                });
                bookList.Add(new NewsPaper
                {
                    Name = "The Daily Telegraph", Category = "News", Price = 1
                });
                bookList.Add(new NewsPaper
                {
                    Name = "Financial Times", Category = "Economy", Price = 1
                });
                bookList.Add(new NewsPaper
                {
                    Name = "Le Figaro", Category = "News", Price = 1
                });

                Session["PrintEdition"] = bookList;
            }
            else //if (Session["Book"] != null)
            {
                bookList = (List<PrintEdition>)Session["PrintEdition"];
            }
            return View(bookList);
        }
        public ActionResult GetList()
        {
            saver = new SaveService();
            listData = new StringBuilder(130);
            List<PrintEdition> bookList = (List<PrintEdition>)Session["PrintEdition"];
            List<Book> selectList = new List<Book>();
            foreach (var item in bookList)
            {            
                if (item is IBookAble)
                {
                    var book = (Book)item;
                    selectList.Add(book);
                }
            }
            foreach (Book item in selectList)
            {
                listData.AppendLine($"Name: {item.Name} Author: {item.Author} Publisher: {item.Publisher} Price: {item.Price.ToString()}");
            }
            saver.GetList(listData.ToString());
            return RedirectToAction("Index");
        }
    }
}