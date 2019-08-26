using Ray.EssayNotes.AutoFac.Model;

namespace Ray.EssayNotes.AutoFac.Repository.IRepository
{
    /// <summary>
    /// 学生仓储interface
    /// </summary>
    public interface IStudentRepository : IBaseRepository<StudentEntity>
    {
        string GetName(long id);
    }
}