using Ray.EssayNotes.AutoFac.Model;
using Ray.EssayNotes.AutoFac.Repository.IRepository;
using System;
using System.Linq;

namespace Ray.EssayNotes.AutoFac.Repository.Repository
{
    /// <summary>
    /// 基类仓储
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        public virtual T Get(long id)
        {
            T instance = Activator.CreateInstance<T>();

            if (instance is StudentEntity stuEntity)
            {
                stuEntity.Id = id;
                stuEntity.Name = "学生张三";
                stuEntity.Grade = 99;
                return stuEntity as T;
            }

            if (instance is TeacherEntity teacherEntity)
            {
                teacherEntity.Id = id;
                teacherEntity.Name = "教师李四";
                teacherEntity.Salary = "10K";
                return teacherEntity as T;
            }

            if (instance is BookEntity bookEntity)
            {
                bookEntity.Id = id;
                bookEntity.Title = "《百年孤独》";
                bookEntity.Writer = "加西亚马尔克斯";
                return bookEntity as T;
            }
            return instance;
        }

        public virtual IQueryable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual long Add(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public virtual void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}