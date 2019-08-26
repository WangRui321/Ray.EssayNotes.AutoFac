using Ray.EssayNotes.AutoFac.Repository.IRepository;
using Ray.EssayNotes.AutoFac.Repository.Repository;
using Ray.EssayNotes.AutoFac.Service.IService;

namespace Ray.EssayNotes.AutoFac.Service.Service
{
    /// <summary>
    /// 学生逻辑处理
    /// </summary>
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="studentRepository"></param>
        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public string GetStuName(long id)
        {
            var stu = _studentRepository.Get(id);
            return stu.Name;
        }
    }
}