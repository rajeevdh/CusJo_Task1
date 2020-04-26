using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CusJoTask.Models;

namespace CusJoTask.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string EmailId { get; set; }

        public byte RoleID { get; set; }

        public Roles Role { get; set; }


    }
}