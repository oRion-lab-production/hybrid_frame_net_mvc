﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Entities
{
    public interface IJsonResponseEntity
    {
        string Result { get; set; }
        string Description { get; set; }
    }
}
