using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankTranctions.Models
{
    public class User
    {
        [Key]
        public int id { get; set; }

        [Column("First Name", TypeName = "varchar(50)")]

        [Required]
        public string FirstName { get; set; }

        [Column("Last Name", TypeName = "varchar(50)")]

        [Required]
        public string LastName { get; set; }

        [Column("Gender", TypeName = "varchar(50)")]
        [Required]
        public string Gender { get; set; }

        [Required]

        [Column("Email", TypeName = "varchar(50)")]

        [RegularExpression("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$", ErrorMessage = "Invaild Email")]
        public string Email { get; set; }


        [Column("Password", TypeName = "varchar(50)")]
        [Required(ErrorMessage = "Password is must")]
        [RegularExpression("(?=^.{8,}$)((?=.*\\d)|(?=.*\\W+))(?![.\\n])(?=.*[A-Z])(?=.*[a-z]).*$", ErrorMessage =
           "UpperCasse LowerCase Number symboly min 8")]
        public string Password { get; set; }

        public string Country { get; set; }
        public string State { get; set; }



    }
    
}
