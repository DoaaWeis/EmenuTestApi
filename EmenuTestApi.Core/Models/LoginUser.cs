using EmenuTestApi.Shared.ErrorCode;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmenuTestApi.Core.Models
{
    public class LoginUser
    {

        [Required(ErrorMessage = ValidationErrorsCodes.Required)]
        public string? UserName { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string? Password { get; set; }
    }
}
