using System.ComponentModel.DataAnnotations;

namespace BookstoreApi.Dtos
{
    public class CreateCategoryDto
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}