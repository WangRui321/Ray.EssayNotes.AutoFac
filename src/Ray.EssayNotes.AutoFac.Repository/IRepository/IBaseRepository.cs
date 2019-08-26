using Ray.EssayNotes.AutoFac.Model;
using System.Linq;

namespace Ray.EssayNotes.AutoFac.Repository.IRepository
{
    /// <summary>
    /// 基类仓储interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> where T : BaseEntity
    {
        T Get(long id);

        IQueryable<T> GetAll();

        long Add(T entity);

        void Update(T entity);

        void Delete(long id);
    }
}