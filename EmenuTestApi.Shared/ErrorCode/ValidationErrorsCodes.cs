using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmenuTestApi.Shared.ErrorCode
{
    
    public class ValidationErrorsCodes
    {
        public const string Required = "1";
        public const string MaxLength50 = "21";
        public const string MaxLength128 = "22";
        public const string MaxLength256 = "23";
        public const string MaxLength4000 = "24";
        public const string MaxLength15 = "25";
        public const string MaxLength512 = "26";
        public const string AlreadyExist = "3";
        public const string HasRealatedRecord = "4";
        public const string InvalidParent = "5";
        public const string OnlyNum = "6";
        public const string NotFoundInDataBase = "7";


    }
}
