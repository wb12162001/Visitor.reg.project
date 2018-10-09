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
    /// interface For dbo.VR_SITES.
    /// </summary>
    public interface  IVR_SITESService
    {

        #region Interfaces

        Result<VR_SITESModel> Login(VR_SITESModel dto);

        void Logout();

        int Add(VR_SITESModel vr_sites);

        
        int Update(VR_SITESModel vr_sites);


        int Delete(string uSERID);


        VR_SITESModel GetOne(Hashtable param);

        VR_SITESModel GetOne(string userId);

        IList<VR_SITESModel> GetAllVR_SITES(Hashtable param);

        
        ResultModel<VR_SITESModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");


        #endregion
		
    }
}
