using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modal
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(20), Required]
        public string FirstName { get; set; }
        [StringLength(80), Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string Email { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
