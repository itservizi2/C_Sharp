﻿namespace YourAwesomeBot.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
    }
}