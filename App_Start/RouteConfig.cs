using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using FriendlyUrlExtensions.Helpers;
using System.Threading;
using System.Globalization;

namespace FriendlyUrlExtensions
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.EnableFriendlyUrls(new LocaleSpecficWebformsFriendlyUrlResolver() { BaseLocale = CultureInfo.CurrentCulture.Name });
        }
    }
}
