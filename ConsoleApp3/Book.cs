using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public double Price { get; set; }
    }
}
