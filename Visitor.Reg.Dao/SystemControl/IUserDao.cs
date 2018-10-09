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
    public interface IUserDao
    {
        //List<Menu> GetMenu(int userId);

        UserModel GetOne(string loginName);
        UserModel GetOne(Hashtable param);
        ResultModel<UserModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc");
        int Add(UserModel user);
        int Delete(int ids);
        int Update(UserModel user);

        IList<UserModel> GetAllUser();
    }


}
