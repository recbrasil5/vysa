using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Routing;

namespace VYSA.WebApi.Extensions
{
    public static class HttpRequestMessageExtensions
    {
        private const string HttpContext = "MS_HttpContext";
        private const string RemoteEndpointMessage = "System.ServiceModel.Channels.RemoteEndpointMessageProperty";
        private const string OwinContext = "MS_OwinContext";
        //private const string System_Net_HttpListenerContext = "System.Net.HttpListenerContext";

        public static string GetClientIpAddress(this HttpRequestMessage request)
        {
            if (request.Properties.ContainsKey(HttpContext))
            {
                dynamic ctx = request.Properties[HttpContext];
                if (ctx != null)
                {
                    return ctx.Request.UserHostAddress;
                }
            }

            if (request.Properties.ContainsKey(RemoteEndpointMessage))
            {
                dynamic remoteEndpoint = request.Properties[RemoteEndpointMessage];
                if (remoteEndpoint != null)
                {
                    return remoteEndpoint.Address;
                }
            }

            // Self-hosting using Owin. Needs reference to Microsoft.Owin.dll. 
            if (request.Properties.ContainsKey(OwinContext))
            {
                dynamic owinContext = request.Properties[OwinContext];
                if (owinContext != null)
                {
                    return owinContext.Request.RemoteIpAddress;
                }
            }

            return null;
        }

        //public static string GetRequestRawlUrl(this HttpRequestMessage request)
        //{
        //    if (request.Properties.ContainsKey(HttpContext))
        //    {
        //        dynamic ctx = request.Properties[HttpContext];
        //        if (ctx != null)
        //        {
        //            return ctx.Request.Url.AbsoluteUri;
        //        }
        //    }

        //    // Self-hosting using Owin. Needs reference to Microsoft.Owin.dll. 
        //    if (request.Properties.ContainsKey(OwinContext))
        //    {
        //        dynamic owinContext = request.Properties[OwinContext];
        //        if (owinContext != null)
        //        {
        //            var env = owinContext.Request.Environment;
        //            var listenerContext = (System.Net.HttpListenerContext)env[System_Net_HttpListenerContext];
        //            return listenerContext.Request.RawUrl;
        //        }
        //    }

        //    return null;
        //}
    }
}