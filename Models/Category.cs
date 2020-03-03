using System;
using System.Collections.Generic;

namespace ToDoRead.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}