namespace Ray.EssayNotes.AutoFac.Model
{
    /// <summary>
    /// 教师实体
    /// </summary>
    public class TeacherEntity : BaseEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 工资
        /// </summary>
        public string Salary { get; set; }
    }
}