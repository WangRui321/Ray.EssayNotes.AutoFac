﻿//系统包
using System;
using System.Linq;
//本地项目包
using Ray.EssayNotes.AutoFac.Domain.Entity;
using Ray.EssayNotes.AutoFac.Domain.IRepository;

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
            //没有连接数据库，利用反射，造个假数据返回用于测试
            T instance = Activator.CreateInstance<T>();

            var stuEntity = instance as StudentEntity;
            if (stuEntity != null)
            {
                stuEntity.Id = id;
                stuEntity.Name = "学生张三";
                stuEntity.Grade = 99;
                return stuEntity as T;
            }

            var teacherEntity = instance as TeacherEntity;
            if (teacherEntity != null)
            {
                teacherEntity.Id = id;
                teacherEntity.Name = "教师李四";
                teacherEntity.Salary = "10K";
                return teacherEntity as T;
            }

            var bookEntity = instance as BookEntity;
            if (bookEntity != null)
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
