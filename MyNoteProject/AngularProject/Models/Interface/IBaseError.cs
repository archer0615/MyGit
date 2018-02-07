﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Models.Interface
{
    public interface IBaseError
    {
        string PropertyName { get; }
        string PropertyExceptionMessage { get; }
    }
}
