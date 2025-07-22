namespace LessonThirtyThree.Models
{
    using System.ComponentModel.DataAnnotations;

   
        public class BookDto
        {
            [Required]
            public required string Title { get; set; }

            [Required]
            public required string Author { get; set; }

            [Range(1000, 9999)]
            public int Year { get; set; }

            [Range(0, int.MaxValue)]
            public int CopiesAvailable { get; set; }
        }
    
}
