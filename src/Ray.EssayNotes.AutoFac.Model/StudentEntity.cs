namespace Ray.EssayNotes.AutoFac.Model
{
    /// <summary>
    /// 学生实体
    /// </summary>
    public class StudentEntity : BaseEntity
    {
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>年级</summary>
        public int Grade { get; set; }
    }
}