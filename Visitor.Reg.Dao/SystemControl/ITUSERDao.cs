using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visitor.Reg.Entity.CommonModel;
using Visitor.Reg.Entity.Models;

namespace Visitor.Reg.Dao.SystemControl
{
    /// <summary>
    /// Interface of Data Access Layer For dbo.TUSER.
    /// </summary>
    public interface ITUSERDao
    {
		#region Interfaces
        
        TUSERModel GetOne(Hashtable param);

        TUSERModel GetOne(string userId);
        ResultModel<TUSERModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
        int Add(TUSERModel tuser);
        int Delete(string uSERID);
        int Update(TUSERModel tuser);

        IList<TUSERModel> GetAllTUSER(Hashtable para);
        #endregion
    }
}
