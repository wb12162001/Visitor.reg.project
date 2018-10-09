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
    /// interface For dbo.VR_VISIT.
    /// </summary>
    public interface  IVR_VISITService
    {

        #region Interfaces
		
        int Add(VR_VISITModel vr_visit);

        
        int Update(VR_VISITModel vr_visit);


        int Delete(int iD);


        VR_VISITModel GetOne(Hashtable param);

        IList<VR_VISITModel> GetAllVR_VISIT(Hashtable para);

        
        ResultModel<VR_VISITModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");


        #endregion
		
    }
}
