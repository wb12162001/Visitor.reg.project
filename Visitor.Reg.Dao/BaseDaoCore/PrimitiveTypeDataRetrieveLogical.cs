﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Reg.Entity.CommonModel;

namespace Visitor.Reg.Dao.BaseDaoCore
{
    /// <summary>
    /// 基元类型数据检索逻辑
    /// </summary>
    public  class PrimitiveTypeDataRetrieveLogical: DataRetrieveLogical
    {
        public PrimitiveTypeDataRetrieveLogical(string tableMame, string likeQueryStr, QueryBase queryBase) : base(tableMame, likeQueryStr, queryBase) { }
    }
}
