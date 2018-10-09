using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StructureMap;

namespace Visitor.Reg.Service.StructureMap
{
    public class MapRegistry : Registry
    {
        public MapRegistry()
        {
            //Services
            //For(typeof(Visitor.Reg.Service.SystemControl.IUserService)).Use(typeof(Visitor.Reg.Service.SystemControl.UserService));
            For(typeof(Visitor.Reg.Service.SystemControl.ITUSERService)).Use(typeof(Visitor.Reg.Service.SystemControl.TUSERService));
            For(typeof(Visitor.Reg.Service.SystemControl.IVR_SITESService)).Use(typeof(Visitor.Reg.Service.SystemControl.VR_SITESService));
            For(typeof(Visitor.Reg.Service.SystemControl.IVR_VISITService)).Use(typeof(Visitor.Reg.Service.SystemControl.VR_VISITService));

            For(typeof(Visitor.Reg.Service.Services.IBaseService)).Use(typeof(Visitor.Reg.Service.Services.BaseService));
        }
    }
}
