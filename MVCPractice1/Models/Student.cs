using System.ComponentModel.DataAnnotations;

namespace MVCPractice1.Models
{
    public class Student
    {
        /*Id (Auto Increment)

        Name

        Class

        Age

        IsActive (boolean)*/

        [Key]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public string sclass { get; set; }

        public int age { get; set; }

        public bool isActive { get; set; } = true;
    }
}
