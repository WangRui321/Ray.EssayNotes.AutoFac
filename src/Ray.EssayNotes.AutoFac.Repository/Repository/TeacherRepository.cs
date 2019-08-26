using Ray.EssayNotes.AutoFac.Model;
using Ray.EssayNotes.AutoFac.Repository.IRepository;

namespace Ray.EssayNotes.AutoFac.Repository.Repository
{
    /// <summary>
    /// 教师仓储
    /// </summary>
    public class TeacherRepository : BaseRepository<TeacherEntity>, ITeacherRepository
    {
        public string GetName(long id)
        {
            return "教师李四";
        }
    }
}