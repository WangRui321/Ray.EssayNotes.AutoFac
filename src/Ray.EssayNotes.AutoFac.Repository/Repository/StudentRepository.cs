using Ray.EssayNotes.AutoFac.Model;
using Ray.EssayNotes.AutoFac.Repository.IRepository;

namespace Ray.EssayNotes.AutoFac.Repository.Repository
{
    /// <summary>
    /// 学生仓储
    /// </summary>
    public class StudentRepository : BaseRepository<StudentEntity>, IStudentRepository
    {
        public string GetName(long id)
        {
            return "学生张三";//造个假数据返回
        }
    }
}