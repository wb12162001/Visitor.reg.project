using System;
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
using System.Collections;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Visitor.Reg.Service.SystemControl
{
    public class UserService : IUserService
    {
        private IAuthenticationManager AuthenticationManager => HttpContext.Current.GetOwinContext().Authentication;

        public IUserDao userDao { get; set; }
        public UserService()
        {

            userDao = StructureMapWapper.GetInstance<IUserDao>();
        }

        //public List<Menu> GetMyMenus(int userId)
        //{
        //    return userDao.GetMenu(userId);
        //}

        public ClaimsIdentity CreateIdentity(UserModel user, string authenticationType)
        {
            ClaimsIdentity _identity = new ClaimsIdentity(DefaultAuthenticationTypes.ApplicationCookie);
            _identity.AddClaim(new Claim(ClaimTypes.Name, user.LoginName));
            _identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            _identity.AddClaim(new Claim("http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider", "ASP.NET Identity"));
            _identity.AddClaim(new Claim("DisplayName", user.RealName));
            return _identity;
        }

        public Result<UserModel> Login(UserModel dto)
        {
            var res = new Result<UserModel>();
            try
            {
                var user = userDao.GetOne(dto.LoginName);
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
                    if (user.Password != dto.Password.ToMD5())
                        res.msg = "登录密码错误";
                    else if (user.IsDeleted)
                        res.msg = "用户已被删除";
                    else if (user.Status == UserStatus.未激活)
                        res.msg = "账号未被激活";
                    else if (user.Status == UserStatus.禁用)
                        res.msg = "账号被禁用";
                    else
                    {
                        res.flag = true;
                        res.msg = "登录成功";
                        res.data = user;

                        //写入注册信息
                        DateTime expiration = dto.IsRememberMe
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
                        AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = user.IsRememberMe }, _identity);
                    }
                }
            }
            catch (Exception ex)
            {
                res.msg = ex.Message;
                
            }
            return res;
        }

        public int Add(UserModel user)
        {
          return userDao.Add(user);
        }

        public ResultModel<UserModel> GetWithPages(QueryBase queryBase, string orderBy, string orderDir = "desc")
        {
            return userDao.GetWithPages(queryBase, orderBy, orderDir);
        }

        public void Logout()
        {
            //方法一登出,
            //Visitor.Reg.Core.TicketTool.Logout();
            //FormsAuthentication.SignOut();
            //方法二登出
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            //throw new NotImplementedException();
        }



        public bool Add(List<UserModel> models)
        {
            throw new NotImplementedException();
        }

        public int Update(UserModel user)
        {
            return userDao.Update(user);
        }

        public bool Update(IEnumerable<UserModel> users)
        {
            throw new NotImplementedException();
        }

        public int Delete(int ids)
        {
            return userDao.Delete(ids);
        }

        public bool Delete(Expression<Func<UserModel, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public UserModel GetOne(Hashtable param)
        {
            return userDao.GetOne(param);
        }
    }
}
