using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Visitor.Reg.Common.Enums;
using Visitor.Reg.Core;
//using Visitor.Reg.Core.StructureMapWapperUtils;
using Visitor.Reg.Entity.Models;
using Visitor.Reg.Service.SystemControl;
using Visitor.Reg.StructureMap;

namespace WebApplication.Controllers
{
    /// <summary>
    /// AdmBase
    /// </summary>
    public class AdminBaseController : Controller
    {

        public ITUSERService userService { get; set; }

        public IVR_SITESService vr_sitesService { get; set; }

        public IVR_VISITService vr_visitService { get; set; }

        /// <summary>
        /// 当前登录用户
        /// </summary>
        protected VR_SITESModel CurrentUser { get; private set; }

        /// <summary>
        /// 是否登录
        /// </summary>
        protected bool IsLogined { get; set; }

        public AdminBaseController()
        {
            userService = StructureMapWapper.GetInstance<ITUSERService>();
            vr_sitesService = StructureMapWapper.GetInstance<IVR_SITESService>();
            vr_visitService = StructureMapWapper.GetInstance<IVR_VISITService>();
        }



        /// <summary>
        /// Initialize
        /// </summary>
        /// <param name="requestContext"></param>
        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            // TODO

            //验证登录方法式1
            //用户信息处理
            /*
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity as FormsIdentity;
                CurrentUser = new UserModel
                {
                    Id = Convert.ToInt32(user.Ticket.UserData),
                    LoginName = User.Identity.Name
                };
            }

            IsLogined = CurrentUser != null && CurrentUser.Id > 0;
            
            ViewRecord(requestContext);
            */

            //验证登录方法式2
            if (User.Identity.IsAuthenticated)
            {
                ClaimsIdentity claimsIdentity = HttpContext.User.Identity as ClaimsIdentity;
                if (claimsIdentity != null)
                {
                    CurrentUser = new VR_SITESModel
                    {
                        USERID = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value,
                        //FULLNAME = claimsIdentity.FindFirst(ClaimTypes.Name).Value
                    };
                }
            }
        }

        /// <summary>
        /// 访问记录
        /// </summary>
        /// <param name="_context"></param>
        void ViewRecord(RequestContext _context)
        {
            
        }

        /// <summary>
        /// 获取指定菜单下的按钮
        /// </summary>
        /// <param name="parentId"></param>
        protected virtual void GetButtons(int parentId)
        {
            //获取我的角色
            //var userId = CurrentUser.;
            //var myMenus = userService.GetMyMenus(userId);

            //ViewBag.MyButtons = myMenus.Where(item => item.ParentId == parentId && item.Type == MenuType.按钮)
            //    .OrderBy(item => item.Id)
            //    .ToList();
        }
    }
}