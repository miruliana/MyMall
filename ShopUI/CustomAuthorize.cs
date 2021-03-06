﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using ShopServices.Services;

namespace ShopUI
{

	public class CustomAuthorize : System.Web.Http.AuthorizeAttribute
	{
		public override void OnAuthorization(HttpActionContext actionContext)
		{
			//if (actionContext.Request.RequestUri.Scheme != Uri.UriSchemeHttps)
			//{
			//	actionContext.Response = new HttpResponseMessage(System.Net.HttpStatusCode.Forbidden)
			//	{
			//		ReasonPhrase = "HTTPS Required"
			//	};
			//}
			//else
			//{
			//	base.OnAuthorization(actionContext);
			//}
		}
		protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
		{
			if (actionContext == null)
				throw new ArgumentNullException("actionContext");
			actionContext.Response = CreateUnauthorizedResponse(actionContext
				.ControllerContext.Request);
		}

		private HttpResponseMessage CreateUnauthorizedResponse(HttpRequestMessage request)
		{
			var result = new HttpResponseMessage()
			{
				StatusCode = HttpStatusCode.Unauthorized,
				RequestMessage = request
			};
			if (HttpContext.Current != null)
			{
				string url = HttpContext.Current.Request.UrlReferrer.AbsolutePath;
				if (url.EndsWith("Default.aspx"))
				{
					string fullyQualifiedUrl = HttpContext.Current.Request.UrlReferrer.GetLeftPart(UriPartial.Authority);
					result.Headers.Location = new Uri(fullyQualifiedUrl + "/Login.aspx");
				}
			}
			
			return result;
		}
 
		
	}
}