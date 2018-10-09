using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Visitor.Reg.Core.StructureMapWapperUtils;
using Visitor.Reg.Dao.Daos;
using Visitor.Reg.Entity.Models;
using StructureMap;

namespace Visitor.Reg.Dao.BaseDaoCore
{
    /// <summary>
    /// 根据前台传递过来的MenuID获取菜单信息，用于自动构造数据和绑定界面
    /// </summary>
    public class MenuDataUtil
    {
        private IDaoFrame daoFrame = null;

        public MenuDataUtil()
        {
            var container = new Container();
            daoFrame = container.GetInstance<IDaoFrame>();
        }

        /// <summary>
        /// 获取菜单详细情况
        /// </summary>
        /// <param name="menuId"></param>
        public Menu GetMenuDetail(string menuId)
        {
            var menu = daoFrame.GetOne<Menu>(Convert.ToInt32(menuId));
            return menu;
        }
    }
}
