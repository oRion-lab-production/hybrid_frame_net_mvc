using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction.GenericModels.Configurations
{
    public class ApiSettings
    {
        public APIsUrl APIsUrl { get; set; }

        public ApiSettings() { 
            APIsUrl = new APIsUrl();    
        }    
    }


    public class APIsUrl
    {
        public string rnd_app { get; set; }
    }
}
