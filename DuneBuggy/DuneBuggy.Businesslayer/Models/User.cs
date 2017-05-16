using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace DuneBuggy.Businesslayer.Models
{
    public class User
    {  
        public int Id { get; set; }

        [Required]
        [Display(Name = "User name")]
        public string Username { get; set; }
  
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public System.DateTime RegDate { get; set; }

        public string Email { get; set; }

    }
}

