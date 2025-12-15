using System.ComponentModel.DataAnnotations;

namespace MVCPractice2.Models
{
    public class CompanyModel
    {
        public  int id { get; set; }

        [Required(ErrorMessage ="name is required")]
        public string name { get; set; }

        [Required(ErrorMessage ="email is required")]
        public string email{ get; set; }

        [Required(ErrorMessage ="age is required")]
        [Range(25,50, ErrorMessage ="age is not under the range")]
        public int age{ get; set; }

        [Required(ErrorMessage ="dept is required")]
        public string dept { get; set; }

        [Required(ErrorMessage ="ssalary is required")]
        [Range(15000, 100000, ErrorMessage ="Basic Salary is out of range")]
        public double salary{ get; set; }
    }
}
