﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;

namespace Visitor.Reg.Core
{
    public class TicketTool
    {
        /// <summary>
        /// 创建一个票据，放在cookie中
        /// 票据中的数据经过加密，解决了cookie的安全问题。
        /// </summary>
        /// <param name="username"></param>
        public static void SetCookie(string username, string userData, DateTime expiration)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, username, DateTime.Now, expiration, false, userData, FormsAuthentication.FormsCookiePath);
            FormsAuthentication.SetAuthCookie(username, true, FormsAuthentication.FormsCookiePath);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            FormsIdentity identity = new FormsIdentity(ticket);
            HttpCookie newCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
            {
                HttpOnly = true,
                Expires = expiration
            };
            HttpContext.Current.Response.Cookies.Add(newCookie);
        }
        /// <summary>
        /// 通过此法判断登录
        /// </summary>
        /// <returns>已登录返回true</returns>
        public static bool IsLogin()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
        /// <summary>
        /// 退出登录
        /// </summary>
        public static void Logout()
        {
            FormsAuthentication.SignOut();
        }
        /// <summary>
        /// 取得登录用户名
        /// </summary>
        /// <returns></returns>
        public static string GetUserName()
        {
            return HttpContext.Current.User.Identity.Name;
        }
        /// <summary>
        /// 取得票据中数据
        /// </summary>
        /// <returns></returns>
        public static string GetUserData()
        {
            return (HttpContext.Current.User.Identity as FormsIdentity).Ticket.UserData;
        }
    }
}
