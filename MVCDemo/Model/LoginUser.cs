using System.ComponentModel.DataAnnotations;

namespace MVCDemo.Model
{
    public class LoginUser
    {
        [Required(ErrorMessage ="Yo! Man, User Name can't be Empty!!!!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Yo! Man, Password can't be Empty!!!!")]
        public string Password { get; set; }
    }
}
