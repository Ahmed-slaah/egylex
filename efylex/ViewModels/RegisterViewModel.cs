using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace egylex.ViewModels
{
    public class RegisterViewModel
    {
        [Required,MinLength(3),MaxLength(40)]
        public string FirstName { get; set; }
        [Required,MinLength(3),MaxLength(40)]
        public string LastName { get; set; }
        [Remote("IsEmailAvailable", "Account", ErrorMessage = "This email is already taken!")]
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)
            , RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Password should be at least 8 chars and cantains one digit, and one special char.")]
        public string Password { get; set; }
        [Compare("Password")]
        public string PasswordConfirmed { get; set; }
        public IFormFile PhotoUrl { get; set; }
    }
}
