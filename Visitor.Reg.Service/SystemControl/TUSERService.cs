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
using System.Net;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace Visitor.Reg.Service.SystemControl
{
    /// <summary>
    /// BLL Layer For dbo.TUSER.
    /// </summary>
    public class TUSERService : ITUSERService
    {
        #region Constructor
        private IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;
        private ITUSERDao tuserDao { get; set; }
        
		/// <summary>
		/// Default constructor
		/// </summary>
		public TUSERService()
		{
            tuserDao = StructureMapWapper.GetInstance<ITUSERDao>();
		}
        #endregion

        #region Interfaces
        public ClaimsIdentity CreateIdentity(TUSERModel user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.FULLNAME));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.USERID));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.DESCRIPTION));
            return _identity;
        }
        public Result<TUSERModel> Login(TUSERModel dto)
        {
            var res = new Result<TUSERModel>();
            try
            {
                var user = tuserDao.GetOne(dto.USERID);
                if (user == null)
                    res.msg = "无效的用户";
                else
                {
                    //记录登录日志
                    /*
                    loginLogDao.Add(new LoginLog
                    {
                        UserId = user.Id,
                        LoginName = user.LoginName,
                        IP = WebHelper.GetClientIP(),
                        Mac = WebHelper.GetClientMACAddress()
                    });*/
                    if (user.PASSID != dto.PASSID)
                        res.msg = "登录密码错误";
                    else
                    {
                        res.flag = true;
                        res.msg = "登录成功";
                        res.data = user;

                        //写入注册信息
                        DateTime expiration = true
                            ? DateTime.Now.AddDays(7)
                            : DateTime.Now.Add(FormsAuthentication.Timeout);
                        /*
                        FormsAuthentication.SetAuthCookie(user.LoginName, true, FormsAuthentication.FormsCookiePath);

                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2,
                            user.LoginName,
                            DateTime.Now,
                            expiration,
                            true,
                            user.Id.ToString(),
                            FormsAuthentication.FormsCookiePath);
                        FormsIdentity identity = new FormsIdentity(ticket);

                        HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,
                            FormsAuthentication.Encrypt(ticket))
                        {
                            HttpOnly = true,
                            Expires = expiration
                        };
                        HttpContext.Current.Response.Cookies.Add(cookie);
                        */
                        //方法一: from模式记录用户登录
                        //Visitor.Reg.Core.TicketTool.SetCookie(user.LoginName, user.Id.ToString(), expiration);
                        //方法二: ClaimsIdentity 记录用户登 录
                        var _identity = CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                        AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, _identity);
                    }
                }
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;

            }
            return res;
        }

        public void Logout()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

        public int Add(TUSERModel tuser)
        {
          return tuserDao.Add(tuser);
        }

        
        public int Update(TUSERModel tuser)
        {
            return tuserDao.Update(tuser);
        }



        public int Delete(string uSERID)
        {
            return tuserDao.Delete(uSERID);
        }



        public TUSERModel GetOne(Hashtable param)
        {
            return tuserDao.GetOne(param);
        }

        public TUSERModel GetOne(string userId)
        {
            return tuserDao.GetOne(userId);
        }

        public IList<TUSERModel> GetAllTUSER(Hashtable param)
        {
            return tuserDao.GetAllTUSER(param);
        }

        public IList<TUSERModel> GetAllTUSER(string letter)
        {
            var param = new Hashtable();
            param.Add("Letter", string.Format("{0}%", letter));
            return tuserDao.GetAllTUSER(param);
        }

        public ResultModel<TUSERModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return tuserDao.GetWithPages(queryBase, orderBy, orderDir);
        }

        #endregion
		
    }
}
