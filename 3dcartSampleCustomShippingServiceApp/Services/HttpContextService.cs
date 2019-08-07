using _3dcartSampleCustomShippingServiceApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;

namespace _3dcartSampleCustomShippingServiceApp.Services
{
    public class HttpContextService : IHttpContextService
    {
        public HttpContextBase Context
        {
            get { return new HttpContextWrapper(HttpContext.Current); }
        }

        public HttpRequestBase Request
        {
            get { return Context.Request; }
        }

        public HttpResponseBase Response
        {
            get { return Context.Response; }
        }

        public NameValueCollection FormOrQuerystring
        {
            get
            {
                if (Request.RequestType == "POST")
                {
                    return Request.Form;
                }

                return Request.QueryString;
            }
        }
    }
}