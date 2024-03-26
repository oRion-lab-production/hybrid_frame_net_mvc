using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.GenericModels
{
    public class ConstantValue
    {
        public enum JsonResult
        {
            Failure = 0,
            Success = 1,
            ModelStateInvalid = 3,
            TokenExpired = 4
        }
    }
}
