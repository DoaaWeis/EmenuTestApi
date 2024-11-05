using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmenuTestApi.Core.Models
{
   public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Designation { get; set; }
        public DateTime JoiningDate { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PinCode { get; set; }
        public string ImagePath { get; set; }
    }
}
