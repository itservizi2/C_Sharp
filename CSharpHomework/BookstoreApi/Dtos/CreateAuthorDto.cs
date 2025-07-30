
using System.ComponentModel.DataAnnotations;


    namespace BookstoreApi.Dtos
    {
        public class CreateAuthorDto
        {
            [Required]
            [StringLength(100)]
            public string Name { get; set; }
        }
    }

