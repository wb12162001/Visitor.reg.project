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
    /// Interface of Data Access Layer For dbo.VR_SITES.
    /// </summary>
    public interface IVR_SITESDao
    {
		#region Interfaces
        
        VR_SITESModel GetOne(Hashtable param);
        VR_SITESModel GetOne(string userId);
        ResultModel<VR_SITESModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
        int Add(VR_SITESModel vr_sites);
        int Delete(string uSERID);
        int Update(VR_SITESModel vr_sites);

        IList<VR_SITESModel> GetAllVR_SITES(Hashtable param);
        #endregion
    }
}
