using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Entities.Components
{
    public abstract class DataTable_getBaseModel : IDataTableEntity, ICloneable
    {
        public virtual int draw { get; set; }
        public virtual int recordsTotal { get; set; }
        public virtual int recordsFiltered { get; set; }

        public DataTable_getBaseModel()
        {
            draw = 0;
            recordsTotal = 0;
            recordsFiltered = 0;
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }

    public abstract class DataTable_viewBaseModel : IDataTableViewEntity, ICloneable
    {
        public virtual int SeqNo { get; set; }
        public virtual string ActionBtn { get; set; }

        public DataTable_viewBaseModel() { }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
