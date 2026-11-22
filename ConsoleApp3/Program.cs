using ConsoleAppLesson.Datas;
using ConsoleAppLesson.Services;
using System;

namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GenericAppDbContext<Book> db = new GenericAppDbContext<Book>();
            GenericService<Book> service = new GenericService<Book>(db);

            while (true)
            {
                Console.WriteLine("1. GetAll");
                Console.WriteLine("2. GetById");
                Console.WriteLine("3. Add");
                Console.WriteLine("4. Delete");
                Console.WriteLine("0. Exit");

                Console.Write("Secim: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        foreach (var item in service.GetAll())
                        {
                            Console.WriteLine($"{item.Id} {item.Title} {item.Author} {item.Price}");
                        }
                        break;

                    case "2":
                        Console.Write("Id: ");
                        int id = Convert.ToInt32(Console.ReadLine());

                        var result = service.GetById(id);

                        if (result != null)
                            Console.WriteLine($"{result.Id} {result.Title} {result.Price}");
                        else
                            Console.WriteLine("Kitab tapilmadi");

                        break;

                    case "3":
                        Book book = new Book();

                        Console.Write("Title: ");
                        book.Title = Console.ReadLine();

                        Console.Write("Author: ");
                        book.Author = Console.ReadLine();

                        Console.Write("Price: ");
                        book.Price = Convert.ToDouble(Console.ReadLine());

                        service.Add(book);
                        Console.WriteLine("Kitab elave olundu");
                        break;

                    case "4":
                        Console.Write("Id: ");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        service.Delete(deleteId);
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Yanlis secim");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}