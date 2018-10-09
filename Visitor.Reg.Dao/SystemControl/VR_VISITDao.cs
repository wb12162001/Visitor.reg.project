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
    /// Data Access Layer For dbo.VR_VISIT.
    /// </summary>
    public class VR_VISITDao : BaseDao, IVR_VISITDao
    {
        #region Interfaces
        
        public int Add(VR_VISITModel vr_visit)
        {
            object obj= base.Add("InsertVR_VISIT", vr_visit);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int iD)
        {
            return base.Delete("DeleteVR_VISIT", iD);
        }

        public int Update(VR_VISITModel vr_visit)
        {
            return base.Update("UpdateVR_VISIT", vr_visit);
        }


        public VR_VISITModel GetOne(Hashtable param)
        {
            return base.QueryForObject<VR_VISITModel>("GetOneVR_VISIT", param);
        }


        public ResultModel<VR_VISITModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return base.GetWithPages<VR_VISITModel>(queryBase, orderBy, orderDir);
        }

        public IList<VR_VISITModel> GetAllVR_VISIT(Hashtable para)
        {
            IList<VR_VISITModel> list = null;
            list = base.QueryForList<VR_VISITModel>("SelectAllVR_VISIT", para);
            return list;
        }
		#endregion
		
    }
}
