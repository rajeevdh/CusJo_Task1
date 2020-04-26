using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CusJoTask.Dtos
{
    public class UserDto
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string EmailId { get; set; }

        [StringLength(12)]
        public string PhoneNumber { get; set; }

        [Required]
        public byte RoleID { get; set; }

        public DateTime? Birthdate { get; set; }
    }
}