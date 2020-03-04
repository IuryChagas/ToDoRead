using System;
using System.ComponentModel.DataAnnotations;

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
        public string Publisher { get; set; }

        [MinLength(2,ErrorMessage = "Language must have more than two characters!")]
        public string Language { get; set; }

    }
}