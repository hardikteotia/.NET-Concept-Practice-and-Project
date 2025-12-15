using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Model
{
    public class MyStudent
    {
        public int No { get; set; }

        [Required(ErrorMessage ="Name's Required")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Age's Required")]
        [Range(20,40, ErrorMessage ="Age Value is incorrect!!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email's Required")]
        public string EMail { get; set; }

        [Required(ErrorMessage = "Name's Required")]
        public string Address { get; set; }

        public bool isEMailValidated { get; set; }
    }
}
