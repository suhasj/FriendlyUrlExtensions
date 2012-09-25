using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.FriendlyUrls;

namespace FriendlyUrlExtensions.Helpers
{
    public class LocaleSpecficWebformsFriendlyUrlResolver : WebFormsFriendlyUrlResolver
    {
        public string BaseLocale { get; set; }

        public LocaleSpecficWebformsFriendlyUrlResolver()
            : base()
        {
        }

        protected override IList<string> GetExtensions(HttpContextBase httpContext)
        {
            List<string> extensions = new List<string>();

            if (httpContext == null)
            {
                throw new ArgumentNullException("httpContext");
            }

            // Look into the browser accepted languages to decide the locale
            // Return base aspx if locale is en-US
            if (httpContext.Request.UserLanguages.Length == 0 ||
                httpContext.Request.UserLanguages[0].Equals(BaseLocale, StringComparison.OrdinalIgnoreCase))
            {
                return base.GetExtensions(httpContext);
            }

            extensions = base.GetExtensions(httpContext).ToList();

            extensions.Insert(0, "." + httpContext.Request.UserLanguages[0] + AspxExtension);

            return extensions;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        protected override void ProcessHandler(HttpContextBase httpContext, IHttpHandler httpHandler)
        {
            base.ProcessHandler(httpContext, httpHandler);


        }
    }
}