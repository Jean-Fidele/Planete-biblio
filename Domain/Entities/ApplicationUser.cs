using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ApplicationUser:IdentityUser
    {

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastNme { get; set; }

        [Display(Name = "Full name")]
        public string FullName { get; set; }

        [Display(Name = "Sexe")]
        public string Sexe { get; set; }

        [Display(Name = "Adresse")]
        public string Adress { get; set; }
    }

    public class ApplicationRole : IdentityRole
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
