using System.ComponentModel.DataAnnotations;

namespace MVCPractice3.Models
{
    public class productpoco
    {
        public int id { get; set; }

        [Required(ErrorMessage ="name is required")]
        public string name { get; set; }

        [Required(ErrorMessage ="price is required")]
        [Range(10,10000, ErrorMessage ="price is out of range")]
        public double price { get; set; }

        [Required(ErrorMessage ="quantity cant be empty")]
        [Range(1,100,ErrorMessage ="quantity is our of range")]
        public int quantity { get; set; }


        public bool isavailable{ get; set; }
    }
}
