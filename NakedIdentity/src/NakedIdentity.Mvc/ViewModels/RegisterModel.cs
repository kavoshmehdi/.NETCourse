using System.ComponentModel.DataAnnotations;

namespace NakedIdentity.Mvc.ViewModels
{
    public class RegisterModel
    {
        [Required]
        //[DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public int Age { get; set; }
    }
}