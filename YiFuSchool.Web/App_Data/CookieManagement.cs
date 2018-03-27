using Project.Manager;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Web;

namespace PetHospital
{
    public class CookieManagement
    {
        private HttpRequest _Request;
        private HttpResponse _Response;

        internal static string CookieName = "tls_user";
        private static int _Timeout = 30000;

        private NineGong.Tools.Cryptography.DES _DES = new NineGong.Tools.Cryptography.DES("Hyey20100430", "HyeyWl30");

        public CookieManagement(HttpRequest request, HttpResponse response)
        {
            _Request = request;
            _Response = response;
        }

        #region 用户

        public string GetUserID()
        {
            HttpCookie cookie = _Request.Cookies[CookieName];
            if (cookie == null)
                return string.Empty;

            string token = cookie.Value;
            string userID = _DES.Decrypt(token);
            return userID;
        }

        public UserInfo GetUser()
        {
            UserInfo user = null;

            string userID = GetUserID();
            if (string.IsNullOrWhiteSpace(userID) == false)
            {
                UserInfoManager mUser = new UserInfoManager();
                user = mUser.GetUserByID(Guid.Parse(userID));
            }

            return user;
        }

        public void SetUserID(string userID)
        {
            HttpCookie cookie = new HttpCookie(CookieName);
            string token = _DES.Encrypt(userID);
            cookie.Value = token;
            cookie.Expires = DateTime.Now.AddMinutes(_Timeout);
            _Response.Cookies.Add(cookie);
        }

        #endregion

        #region 会员

        public string GetMembersID()
        {
            HttpCookie cookie = _Request.Cookies[CookieName];
            if (cookie == null)
                return string.Empty;

            string token = cookie.Value;
            string membersID = _DES.Decrypt(token);
            return membersID;
        }

        public MembersInfo GetMembers()
        {
            MembersInfo user = null;

            string userID = GetUserID();
            if (string.IsNullOrWhiteSpace(userID) == false)
            {
                MembersInfoManager mim = new MembersInfoManager();
                user = mim.GetMembersByID(Guid.Parse(userID));
            }

            return user;
        }

        public void SetMembersID(string userID)
        {
            HttpCookie cookie = new HttpCookie(CookieName);
            string token = _DES.Encrypt(userID);
            cookie.Value = token;
            cookie.Expires = DateTime.Now.AddMinutes(_Timeout);
            _Response.Cookies.Add(cookie);
        }
        #endregion

        public void RefreshUserID()
        {
            HttpCookie cookie = _Request.Cookies[CookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddMinutes(_Timeout);
                _Response.Cookies.Add(cookie);
            }
        }

        public void RemoveUserID()
        {
            HttpCookie cookie = _Request.Cookies[CookieName];
            if (cookie != null)
            {
                cookie.Expires = DateTime.Now.AddMinutes(-60);
                _Response.Cookies.Add(cookie);
            }
        }
    }
}