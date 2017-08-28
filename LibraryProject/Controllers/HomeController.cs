using LibraryProject.Extention_Classes;
using LibraryProject.Models;
using LibraryProject.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LibraryProject.Controllers
{
    public class HomeController : Controller
    {
        private const string _BOOK_KEY = "book";
        private const string _MAGAZINE_KEY = "magazine";
        private const string _NEWSPAPER_KEY = "newspaper";
        List<Book> bookList;
        List<Magazine> magazineList;
        List<NewsPaper> newsPaperList;
        IndexModel indexModel;

        [HttpGet]
        public ActionResult Index()
        {
            if (Session["LibraryState"] == null)
            {
                indexModel = new IndexModel();
                bookList = new List<Book>();
                magazineList = new List<Magazine>();
                newsPaperList = new List<NewsPaper>();

                bookList.AddRange(new List<Book> { new Book { Name = "Head First C#", Author = "A.Stellman,J.Greene", Publisher = "O'Reilly", Price = 540 },
                    new Book{Name = "LINQ Succinctly", Author = "J.Roberts", Publisher = "Syncfusion", Price = 200},
                    new Book{Name = "Java Script Patterns", Author = "S.Stefanov", Publisher = "O'Reilly", Price = 312 },
                    new Book{Name = "Head First JS Programming", Author = "E.Freeman,E.Robson", Publisher = "O'Reilly", Price = 330 },
                    new Book{Name = "SQL The Complete Reference", Author = "J.Groff,P.Weinberg,A.Oppel", Publisher = "Williams", Price = 158 },
                    new Book{Name = "Getting started with ASP.NET 5.0 Web Forms", Author = "N.Gaylord,Ch.Wenz,P.Rastogi,T.Miranda", Publisher = "O'Reilly", Price = 400 },
                    new Book{Name = "C# 6.0 Complete Guide", Author = "J. & B.Albahairy", Publisher = "Williams", Price = 499 },
                    new Book{Name = "ASP.NET 4.5 in C# and VB", Author = "J.Gaylord", Publisher = "Wrox", Price = 274 },
                    new Book{Name = "Head First SQL", Author = "Lynn Beighley", Publisher = "O'Reilly", Price = 299 },
                    new Book{Name = "Design Patterns via C#", Author = "A.Shevchyk,A.Kasianov,D.Ohrimenko", Publisher = "ITVDN", Price = 830 },
                    new Book{Name = "OOP in C#. Succinctly", Author = "S.Rossel", Publisher = "Syncfusion", Price = 830 }
                });

                magazineList.AddRange(new List<Magazine> { new Magazine{ Name = "MartialMix", Category = "Sport", Price = 16, Publisher = "Williams"},
                    new Magazine{Name = "Fashion", Category = "Fashion", Price = 20, Publisher = "MagGroup" },
                    new Magazine{Name = "Forbs", Category = "Economic", Price = 25, Publisher = "StanleyCo" },
                    new Magazine{Name = "Geek", Category = "IT", Price = 21, Publisher = "StanleyCo"},
                    new Magazine{Name = "Amaizing Wild World", Category = "Nature", Price = 22, Publisher = "StanleyCo" },
                    new Magazine{Name = "Braine Scince", Category = "Psychology", Price = 26, Publisher = "Williams"},
                    new Magazine{Name = "Car Evo", Category = "Car", Price = 24, Publisher = "MagGroup"},
                    new Magazine{Name = "Robo", Category = "Scince", Price = 32, Publisher = "StanleyCo"},
                    new Magazine{Name = "Zadrot", Category = "Games", Price = 16, Publisher = "Williams"},
                    new Magazine{Name = "Design & Creative", Category = "Design", Price = 30, Publisher = "MagGroup"}
                });

                newsPaperList.AddRange(new List<NewsPaper> {new NewsPaper{Name = "The NewYork Times", Category = "News", Price = 7, Publisher = "Williams"},
                    new NewsPaper{Name = "The WallSteet Jornal", Category = "Economy", Price = 7, Publisher = "Williams"},
                    new NewsPaper{Name = "Ring", Category = "Sport", Price = 7, Publisher = "Ronald"},
                    new NewsPaper{Name = "Los Angeles Times", Category = "News", Price = 7, Publisher = "WestCost"},
                    new NewsPaper{Name = "The Washington Post", Category = "News", Price = 7, Publisher = "Croxy"},
                    new NewsPaper{Name = "The Times", Category = "News", Price = 1, Publisher = "Croxy"},
                    new NewsPaper{Name = "The Guardian", Category = "News", Price = 1, Publisher = "WestCost"},
                    new NewsPaper{Name = "The Daily Telegraph", Category = "News", Price = 1, Publisher = "Croxy"},
                    new NewsPaper{Name = "Financial Times", Category = "Economy", Price = 1, Publisher = "Williams"},
                    new NewsPaper{Name = "Le Figaro", Category = "News", Price = 1, Publisher = "WestCost"}
                });

                indexModel.Books = bookList;
                indexModel.Magazines = magazineList;
                indexModel.NewsPapers = newsPaperList;

                Session["LibraryState"] = indexModel;

            }
            if (Session["LibraryState"] != null)
            {
                indexModel = (IndexModel)Session["LibraryState"];
            }
            return View(indexModel);
        }

        [HttpPost]
        public ActionResult GetPublisherList(string id = "", string publisherName = "")
        {
            IndexModel indexModel = (IndexModel)Session["LibraryState"];
            if (id == _BOOK_KEY)
            {
                List<Book> bookList = indexModel.Books;
                List<Book> newBookList = new List<Book>();
                Session["BookMemorry"] = bookList;
                foreach (var item in bookList)
                {
                    if (item.Publisher == publisherName)
                    {
                        newBookList.Add(item);
                    }
                }
                indexModel.Books = newBookList;
            }
            if (id == _MAGAZINE_KEY)
            {
                List<Magazine> magazineList = indexModel.Magazines;
                List<Magazine> newMagazineList = new List<Magazine>();
                Session["MagazineMemorry"] = magazineList;
                foreach (var item in magazineList)
                {
                    if (item.Publisher == publisherName)
                    {
                        newMagazineList.Add(item);
                    }
                }
                indexModel.Magazines = newMagazineList;
            }
            if (id == _NEWSPAPER_KEY)
            {
                List<NewsPaper> newspaperList = indexModel.NewsPapers;
                List<NewsPaper> newNewsPaperList = new List<NewsPaper>();
                Session["NewsPaperMemorry"] = newspaperList;
                foreach (var item in newspaperList)
                {
                    if (item.Publisher == publisherName)
                    {
                        newNewsPaperList.Add(item);
                    }
                }
                indexModel.NewsPapers = newNewsPaperList;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetAllPublisher(string id = "")
        {
            IndexModel indexModel = (IndexModel)Session["LibraryState"];

            if (id == _BOOK_KEY)
            {
                indexModel.Books = (List<Book>)Session["BookMemorry"];
            }
            if (id == _MAGAZINE_KEY)
            {
                indexModel.Magazines = (List<Magazine>)Session["MagazineMemorry"];
            }
            if (id == _NEWSPAPER_KEY)
            {
                indexModel.NewsPapers = (List<NewsPaper>)Session["NewsPaperMemorry"];
            }
            return RedirectToAction("Index");
        }


        public ActionResult GetBooksList()
        {
            IndexModel indexModel = (IndexModel)Session["LibraryState"];
            List<Book> bookList = indexModel.Books;

            string listOfBooks = bookList.GetListToString();
            SaveService.GetTxtList(listOfBooks);

            return RedirectToAction("Index");
        }

        public ActionResult GetNewsPapersList()
        {
            IndexModel indexModel = (IndexModel)Session["LibraryState"];
            List<NewsPaper> newsPaperList = indexModel.NewsPapers;

            string listOfNewsPapers = newsPaperList.GetListToString();
            SaveService.GetTxtList(listOfNewsPapers);

            return RedirectToAction("Index");
        }

        public ActionResult GetBookXmlList()
        {
            IndexModel indexModel = (IndexModel)Session["LibraryState"];
            List<Book> bookList = indexModel.Books;

            SaveService.GetXmlList(bookList);

            return RedirectToAction("Index");
        }
    }
}