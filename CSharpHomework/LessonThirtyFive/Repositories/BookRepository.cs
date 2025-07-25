using LessonThirtyFive.Data;
using LessonThirtyFive.Models;

namespace LessonThirtyFive.Repositories
{
   
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationDbContext context) : base(context)
        {
        }

        
    }
}
