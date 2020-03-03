using System;

namespace ToDoRead.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PageQuantity { get; set; }
        public string Image { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Publisher { get; set; }
        public string Language { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}