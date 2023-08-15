using System.ComponentModel.DataAnnotations;

namespace student_core_api.Model
{
    public class Teacher
    {
        [Key]
       
        public int id { get; set; }
        public string Tname { get; set; } = string.Empty;
    }
}
