using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Entities
{
    public interface IDataTableEntity
    {
        int draw { get; set; }
        int recordsTotal { get; set; }
        int recordsFiltered { get; set; }
    }

    public interface IDataTableViewEntity
    {
        int SeqNo { get; set; }
        string ActionBtn { get; set; }
    }
}
