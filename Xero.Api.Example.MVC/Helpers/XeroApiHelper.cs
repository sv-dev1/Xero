using System;
using System.Configuration;
using Xero.Api.Core;
using Xero.Api.Example.Applications.Partner;
using Xero.Api.Example.Applications.Public;
using Xero.Api.Example.MVC.Stores;
using Xero.Api.Infrastructure.Interfaces;
using Xero.Api.Infrastructure.OAuth;
using Xero.Api.Serialization;

namespace Xero.Api.Example.MVC.Helpers
{
    public class ApplicationSettings
    {
        public string BaseApiUrl { get; set; }
        public Consumer Consumer { get; set; }
        public object Authenticator { get; set; }
    }
    public static class XeroApiHelper
    {
        private static ApplicationSettings _applicationSettings;

        static XeroApiHelper()
        {
            var callbackUrl = "http://localhost:61795/Home/Authorize";
            //var callbackUrl = "https://xeroaccounts.co.uk/Home/Authorize";
            var memoryStore = new MemoryAccessTokenStore();
            var requestTokenStore = new MemoryRequestTokenStore();
            var baseApiUrl = "https://api.xero.com";
            // Consumer details for Application
            var consumerKey = ConfigurationManager.AppSettings["ConsumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["ConsumerSecret"];
            var publicConsumer = new Consumer(consumerKey, consumerSecret);
            var publicAuthenticator = new PublicMvcAuthenticator(baseApiUrl, baseApiUrl, callbackUrl, memoryStore, publicConsumer, requestTokenStore);
            var publicApplicationSettings = new ApplicationSettings
            {
                BaseApiUrl = baseApiUrl,
                Consumer = publicConsumer,
                Authenticator = publicAuthenticator
            };
            _applicationSettings = publicApplicationSettings;
        }
        public static ApiUser User()
        {
            return new ApiUser { Name = Environment.MachineName };
        }
        public static IConsumer Consumer()
        {
            return _applicationSettings.Consumer;
        }
        public static IMvcAuthenticator MvcAuthenticator()
        {
            return (IMvcAuthenticator)_applicationSettings.Authenticator;
        }
        public static IXeroCoreApi CoreApi()
        {
            if (_applicationSettings.Authenticator is IAuthenticator)
            {
                return new XeroCoreApi(_applicationSettings.BaseApiUrl, _applicationSettings.Authenticator as IAuthenticator,
                    _applicationSettings.Consumer, User(), new DefaultMapper(), new DefaultMapper());
            }
            return null;
        }
    }
}
