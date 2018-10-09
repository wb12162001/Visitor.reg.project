using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Visitor.Reg.Common.Enums;
using Visitor.Reg.Core.StructureMapWapperUtils;
using Visitor.Reg.Entity.CommonModel;
using Visitor.Reg.Entity.Models;
using Visitor.Reg.Core.Extentions;
using Visitor.Reg.Service.SystemControl;
using System.Linq.Expressions;
using System.Collections;

namespace WebApplication.Controllers
{
    public class VisitorController : AdminBaseController
    {

        // GET: Visitor
        public ActionResult Index()
        {
            string letter = Request["letter"];
            ViewBag.Letters = GetLetters();
            var dto = userService.GetAllTUSER(letter);
            ViewBag.Users = dto.ToList();

            if (Request.IsAjaxRequest())
            {
                System.Threading.Thread.Sleep(1000 * 3);//模拟处理数据需要的时间

                return PartialView("_UserList");
            }

            return View();
        }

        public ActionResult Modal()
        {
            Models.VisitViewModel model = new Models.VisitViewModel();
            return PartialView("_PartialModal", model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ModalSubmit(Models.VisitViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("_PartialModal", model);
            }
            return PartialView("_PartialModal", model);
        }

        public ActionResult Log()
        {
            Hashtable para = new Hashtable();
            var log = vr_visitService.GetAllVR_VISIT(para);
            ViewBag.logs = log.ToList();
            return View();
        }
        /// <summary>
        /// 获取26个字母
        /// </summary>
        /// <returns></returns>
        private List<string> GetLetters()
{
            List<string> l = new List<string>();
            int iStart = 65; //A
            int iEnd = 90; //Z
            while (iStart <= iEnd)
            {
                l.Add(((char)iStart).ToString());
                iStart++;
            }
            return l;
        }

        [HttpGet]
        public JsonResult GetList()
        {
            var queryBase = new QueryBase
            {
                StartIndex = Request["start"].ToInt(),
                PageSize = Request["length"].ToInt(),
                Draw = Request["draw"].ToInt(),
                Keywords = Request["keywords"]
            };
            Expression<Func<TUSERModel, bool>> exp = item => 1 == 1;
            if (!queryBase.Keywords.IsBlank())
                exp = exp.And(item => item.FULLNAME.Contains(queryBase.Keywords) || item.DESCRIPTION.Contains(queryBase.Keywords));

            var dto = userService.GetWithPages(queryBase, Request["orderBy"], Request["orderDir"]);
            var res = new ResultModel<TUSERModel>
            {
                start = dto.start,
                length = dto.length,
                recordsTotal = dto.recordsTotal,
                data = dto.data.Select(d => new TUSERModel
                {
                    USERID = d.USERID,
                    FULLNAME = d.FULLNAME,
                    EMAIL = d.EMAIL,
                    DESCRIPTION = d.DESCRIPTION,
                    LOCATION = d.LOCATION,
                    PHONE = d.PHONE,
                    EXTNO = d.EXTNO,
                    CELLPHONE = d.CELLPHONE,
                    SHORTNAME = d.SHORTNAME
                }).ToList()
            };
            return Json(res, JsonRequestBehavior.AllowGet);
        }
    }
}