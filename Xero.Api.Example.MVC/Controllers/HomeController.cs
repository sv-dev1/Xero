
using System.Web.Mvc;
using Xero.Api.Core;
using Xero.Api.Core.Model;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Example.MVC.Helpers;
using Xero.Api.Infrastructure.OAuth;
using System.Security.Cryptography;
using System;
using System.Web;
using System.IO;
using Newtonsoft.Json;
using System.Net.Http;

namespace Xero.Api.Example.MVC
{
    public class HomeController : Controller
    {
        //private XeroClient xeroClient;
        private IMvcAuthenticator _authenticator;
        private ApiUser _user;
        public HomeController()
        {
            //xeroClient = new XeroClient();
            _user = XeroApiHelper.User();
            _authenticator = XeroApiHelper.MvcAuthenticator();
        }
        public ActionResult Index()
        {
            return View();
            //var authorizeUrl = _authenticator.GetRequestTokenAuthorizeUrl(_user.Name);
            //return Redirect(authorizeUrl);
        }
        public ActionResult Connect()
        {
            var authorizeUrl = _authenticator.GetRequestTokenAuthorizeUrl(_user.Name);
            return Redirect(authorizeUrl);
        }
        public ActionResult Authorize(string oauth_token, string oauth_verifier, string org)
        {
            //HttpCookie accessTokenCookie = new HttpCookie("accessToken");
            //accessTokenCookie.Values["userName"] = _user.Name;
            //accessTokenCookie.Values["oauthToken"] = oauth_token;
            //accessTokenCookie.Values["oauthVerifier"] = oauth_verifier;
            //accessTokenCookie.Values["org"] = org;
            //accessTokenCookie.Expires.AddMinutes(30);

            var accessToken = _authenticator.RetrieveAndStoreAccessToken(_user.Name, oauth_token, oauth_verifier, org);
            if (accessToken == null)
                return View("NoAuthorized");
            return View(accessToken);
        }
        public ActionResult Example()
        {
            return View();
        }
        [HttpGet]
        public ActionResult CreateInvoice()
        {
            return View();
        }
    }
}
