﻿using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IBaseBLL<TEntity> where TEntity : BaseEntity
    {
    }
}
