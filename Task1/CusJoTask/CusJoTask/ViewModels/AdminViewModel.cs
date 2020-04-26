using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CusJoTask.Models;

namespace CusJoTask.ViewModels
{
    public class AdminViewModel
    {
        public IEnumerable<User> allUsers { get; set; }
        public IEnumerable<Roles> allRoles { get; set; }

        public int userId { get; set; }
        public byte roleId { get; set; }
    }
}