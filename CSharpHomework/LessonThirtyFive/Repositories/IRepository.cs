using System.Linq;
using System.Threading.Tasks;

namespace LessonThirtyFive.Repositories
{

    public interface IRepository<T> where T : class
    {
        
        IQueryable<T> GetAll();

      
        Task<T> GetByIdAsync(int id);

       
        Task<T> AddAsync(T entity);

       
        Task<bool> UpdateAsync(T entity);

       
        Task<bool> DeleteAsync(int id);
    }
}
