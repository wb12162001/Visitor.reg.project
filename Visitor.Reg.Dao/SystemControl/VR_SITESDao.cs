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
    /// Data Access Layer For dbo.VR_SITES.
    /// </summary>
    public class VR_SITESDao : BaseDao, IVR_SITESDao
    {
        #region Interfaces
        
        public int Add(VR_SITESModel vr_sites)
        {
            object obj= base.Add("InsertVR_SITES", vr_sites);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public int Delete(string uSERID)
        {
            return base.Delete("DeleteVR_SITES", uSERID);
        }

        public int Update(VR_SITESModel vr_sites)
        {
            return base.Update("UpdateVR_SITES", vr_sites);
        }


        public VR_SITESModel GetOne(Hashtable param)
        {
            return base.QueryForObject<VR_SITESModel>("GetOneVR_SITES", param);
        }

        public VR_SITESModel GetOne(string userId)
        {
            var para = new Hashtable();
            para.Add("USERID", userId);
            return base.QueryForObject<VR_SITESModel>("GetOneVR_SITES", para);
        }


        public ResultModel<VR_SITESModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return base.GetWithPages<VR_SITESModel>(queryBase, orderBy, orderDir);
        }

        public IList<VR_SITESModel> GetAllVR_SITES(Hashtable para)
        {
            IList<VR_SITESModel> list = null;
            list = base.QueryForList<VR_SITESModel>("SelectAllVR_SITES", para);
            return list;
        }
		#endregion
		
    }
}
