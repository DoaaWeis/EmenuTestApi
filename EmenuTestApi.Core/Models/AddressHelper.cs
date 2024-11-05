using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmenuTestApi.Core.Models
{
    public static class AddressHelper
    {
        public static string FormatAddress(User user)
        {
            return $"{user.Street}, {user.State}, {user.Country} - {user.PinCode}";
        }
    }
}
