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
    /// Interface of Data Access Layer For dbo.VR_VISIT.
    /// </summary>
    public interface IVR_VISITDao
    {
		#region Interfaces
        
        VR_VISITModel GetOne(Hashtable param);
        ResultModel<VR_VISITModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
        int Add(VR_VISITModel vr_visit);
        int Delete(int iD);
        int Update(VR_VISITModel vr_visit);

        IList<VR_VISITModel> GetAllVR_VISIT(Hashtable para);
        #endregion
    }
}
