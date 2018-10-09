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
    public class UserDao : BaseDao, IUserDao
    {
        public int Add(UserModel user)
        {
            object obj= base.Add("InsertUser", user);
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public int Delete(int id)
        {
            return base.Delete("UpdateUser", id);
        }

        public int Update(UserModel user)
        {
            return base.Update("UpdateUser", user);
        }


        public UserModel GetOne(Hashtable param)
        {
            return base.QueryForObject<UserModel>("GetOneUser", param);
        }

        public UserModel GetOne(string loginName)
        {
            var para = new Hashtable();
            para.Add("loginName", loginName);
            return base.QueryForObject<UserModel>("Loginsys", para);
        }

        public ResultModel<UserModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return base.GetWithPages<UserModel>(queryBase, orderBy, orderDir);
        }

        public IList<UserModel> GetAllUser()
        {
            IList<UserModel> list = null;
            list = base.QueryForList<UserModel>("SelectAllUser", null);
            return list;
        }



    }
}
