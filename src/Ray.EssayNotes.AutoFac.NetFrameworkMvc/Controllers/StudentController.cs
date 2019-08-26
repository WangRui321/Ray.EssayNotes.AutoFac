using Ray.EssayNotes.AutoFac.Service.IService;
using System.Web.Mvc;

namespace Ray.EssayNotes.AutoFac.NetFrameworkMvc.Controllers
{
    /// <summary>
    /// 学生Api
    /// </summary>
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="studentService"></param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        /// <summary>
        /// 获取学生姓名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetStuNameById(long id)
        {
            return _studentService.GetStuName(id);
        }
    }
}