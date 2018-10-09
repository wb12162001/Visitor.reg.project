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
    /// interface For dbo.TUSER.
    /// </summary>
    public interface  ITUSERService
    {

        #region Interfaces

        Result<TUSERModel> Login(TUSERModel dto);

        void Logout();
        int Add(TUSERModel tuser);

        
        int Update(TUSERModel tuser);


        int Delete(string uSERID);


        TUSERModel GetOne(Hashtable param);

        TUSERModel GetOne(string userId);

        IList<TUSERModel> GetAllTUSER(Hashtable param);

        IList<TUSERModel> GetAllTUSER(string letter);


        ResultModel<TUSERModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");


        #endregion
		
    }
}
