﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Department.DAL
{
    public interface IEntityDAO
    {
        System.Collections.Generic.IEnumerable<T> GetList<T>();
    }
}
