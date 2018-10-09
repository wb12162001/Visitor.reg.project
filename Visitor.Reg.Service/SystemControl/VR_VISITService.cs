using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using System.Web.Security;
using Visitor.Reg.Common.Enums;
using Visitor.Reg.Core.StructureMapWapperUtils;
using Visitor.Reg.Entity.CommonModel;
using Visitor.Reg.Entity.Models;
using Visitor.Reg.Core.Extentions;
using Visitor.Reg.Dao.SystemControl;

namespace Visitor.Reg.Service.SystemControl
{
    /// <summary>
    /// BLL Layer For dbo.VR_VISIT.
    /// </summary>
    public class VR_VISITService : IVR_VISITService
    {
		#region Constructor
        private IVR_VISITDao vr_visitDao { get; set; }
        
		/// <summary>
		/// Default constructor
		/// </summary>
		public VR_VISITService()
		{
            vr_visitDao = StructureMapWapper.GetInstance<IVR_VISITDao>();
		}
		#endregion

        #region Interfaces
		
        public int Add(VR_VISITModel vr_visit)
        {
          return vr_visitDao.Add(vr_visit);
        }

        
        public int Update(VR_VISITModel vr_visit)
        {
            return vr_visitDao.Update(vr_visit);
        }



        public int Delete(int iD)
        {
            return vr_visitDao.Delete(iD);
        }



        public VR_VISITModel GetOne(Hashtable param)
        {
            return vr_visitDao.GetOne(param);
        }
        
        public IList<VR_VISITModel> GetAllVR_VISIT(Hashtable para)
        {
            return vr_visitDao.GetAllVR_VISIT(para);
        }
        
        public ResultModel<VR_VISITModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return vr_visitDao.GetWithPages(queryBase, orderBy, orderDir);
        }

        #endregion
		
    }
}
