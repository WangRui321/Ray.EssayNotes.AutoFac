using Autofac;
using Ray.EssayNotes.AutoFac.Infrastructure.Ioc;
using Ray.EssayNotes.AutoFac.Service.IService;
using System;

namespace Ray.EssayNotes.AutoFac.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Container.Init();//初始化容器，将需要用到的组件添加到容器中

            PrintStudentName(10001);
            PrintTeacherName(99999);
            PrintBookTitle(123456);
            Console.ReadKey();
        }

        /// <summary>
        /// 输出学生姓名
        /// </summary>
        /// <param name="id"></param>
        public static void PrintStudentName(long id)
        {
            //从容器中解析出对象（可以理解为根生命域(the “root lifetime scope”)
            //这种方式解析出的对象如果不能自动释放，其生命周期则与程序同样长，多了之后可能会造成内存溢出，这里只是为了好理解，并不建议使用
            //建议使用下面用的利用子生命域解析的方式
            IStudentService stuService = Container.Instance.Resolve<IStudentService>();
            string name = stuService.GetStuName(id);
            Console.WriteLine(name);
        }

        /// <summary>
        /// 输出教师姓名
        /// </summary>
        /// <param name="id"></param>
        public static void PrintTeacherName(long id)
        {
            // 创建一个生命域, 解析对象，使用完后, 自动释放掉所有解析资源
            using (ILifetimeScope scope = Container.Instance.BeginLifetimeScope())
            {
                ITeacherService teacherService = scope.Resolve<ITeacherService>();
                string name = teacherService.GetTeacherName(id);
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// 输出书本名称
        /// </summary>
        /// <param name="id"></param>
        public static void PrintBookTitle(long id)
        {
            // 创建一个生命域, 解析对象，使用完后, 自动释放掉所有解析资源
            using (ILifetimeScope scope = Container.Instance.BeginLifetimeScope())
            {
                IBookService bookService = scope.ResolveOptional<IBookService>();
                string title = bookService.GetTitle(id);
                Console.WriteLine(title);
            }
        }
    }
}