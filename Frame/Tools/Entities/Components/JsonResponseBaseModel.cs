using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Entities.Components
{
    public class JsonResponseBaseModel : IJsonResponseEntity, ICloneable
    {
        public virtual string Result { get; set; }
        public virtual string Description { get; set; }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
