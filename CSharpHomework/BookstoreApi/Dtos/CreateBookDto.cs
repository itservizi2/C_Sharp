using System.ComponentModel.DataAnnotations;

namespace BookstoreApi.Dtos
{
    public class CreateBookDto
    {
 

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Range(0.01, 1000)]
        public decimal Price { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}
