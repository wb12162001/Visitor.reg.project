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
    /// Data Access Layer For dbo.TUSER.
    /// </summary>
    public class TUSERDao : BaseDao, ITUSERDao
    {
        #region Interfaces
        
        public int Add(TUSERModel tuser)
        {
            object obj= base.Add("InsertTUSER", tuser);
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
            return base.Delete("DeleteTUSER", uSERID);
        }

        public int Update(TUSERModel tuser)
        {
            return base.Update("UpdateTUSER", tuser);
        }


        public TUSERModel GetOne(Hashtable param)
        {
            return base.QueryForObject<TUSERModel>("GetOneTUSER", param);
        }

        public TUSERModel GetOne(string userId)
        {
            var para = new Hashtable();
            para.Add("USERID", userId);
            return base.QueryForObject<TUSERModel>("GetOneTUSER", para);
        }


        public ResultModel<TUSERModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return base.GetWithPages<TUSERModel>(queryBase, orderBy, orderDir);
        }

        public IList<TUSERModel> GetAllTUSER(Hashtable para)
        {
            //var para = new Hashtable();
            IList<TUSERModel> list = null;
            list = base.QueryForList<TUSERModel>("SelectAllTUSER", para);
            return list;
        }
		#endregion
		
    }
}
