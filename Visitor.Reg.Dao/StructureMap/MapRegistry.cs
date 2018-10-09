using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;
using StructureMap.Configuration.DSL;

namespace Visitor.Reg.Dao.StructureMap
{
    public class MapRegistry : Registry
    {
        public MapRegistry()
        {
            //For(typeof(Visitor.Reg.Dao.SystemControl.IUserDao)).Use(typeof(Visitor.Reg.Dao.SystemControl.UserDao));
            For(typeof(Visitor.Reg.Dao.SystemControl.ITUSERDao)).Use(typeof(Visitor.Reg.Dao.SystemControl.TUSERDao));
            For(typeof(Visitor.Reg.Dao.SystemControl.IVR_SITESDao)).Use(typeof(Visitor.Reg.Dao.SystemControl.VR_SITESDao));
            For(typeof(Visitor.Reg.Dao.SystemControl.IVR_VISITDao)).Use(typeof(Visitor.Reg.Dao.SystemControl.VR_VISITDao));
            For(typeof(Visitor.Reg.Dao.Daos.IDaoFrame)).Use(typeof(Visitor.Reg.Dao.Daos.DaoFrame));
        }
    }
}
