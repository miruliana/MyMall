using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ShopDTO;
using ShopServices.Services;


namespace ShopUI.Controllers
{
	public class AccountApiController : ApiController
	{
		public ServicesManager Services
		{
			get { return ServicesManager.Instance; }
		}
		// POST api/<controller>
		public HttpResponseMessage LogIn([FromBody] UserDTO user)
		{
			if (ModelState.IsValid)
			{
				if (Services.MembershipService.ValidateUser(user.Name, user.Password))
				{
					Services.FormsAuthenticationService.SignIn(user.Name, false);
				
					//if (HttpContextFactory.Current != null)
					//	HttpContextFactory.Current.Session["User"] = user;
					var response = Request.CreateResponse(HttpStatusCode.OK);
					string fullyQualifiedUrl = Request.RequestUri.GetLeftPart(UriPartial.Authority);
					response.Headers.Location = new Uri(fullyQualifiedUrl + "/Default.aspx");
					//HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
					//response.Headers.Location = new Uri(HttpContext.Current.Request.UrlReferrer.Scheme + "://" + HttpContext.Current.Request.UrlReferrer.Authority + "/Default.aspx");
					return response;
				}
				ModelState.AddModelError("", "The user name or password provided is incorrect.");
			}
			return Request.CreateResponse(HttpStatusCode.Forbidden, "The user name or password provided is incorrect.");
		
		}
		public HttpResponseMessage Register([FromBody] UserDTO user)
		{
			string responseMessage = "";
			if (ModelState.IsValid)
			{
				// Attempt to register the user
				var createStatus = Services.MembershipService.CreateUser(user.Name, user.Password, user.UserEmailAddress);

				if (createStatus == System.Web.Security.MembershipCreateStatus.Success)
				{
					Services.FormsAuthenticationService.SignIn(user.Name, false /* createPersistentCookie */);
					return Request.CreateResponse(HttpStatusCode.OK);
				}
				responseMessage = ShopServices.AuthenticationService.StatusCode.ErrorCodeToString(createStatus);
				ModelState.AddModelError("", responseMessage);
			}
			return Request.CreateResponse(HttpStatusCode.BadRequest, responseMessage);
		}
		public HttpResponseMessage LogOut()
		{
			Services.FormsAuthenticationService.SignOut();
			//if (HttpContextFactory.Current != null)
			//	HttpContextFactory.Current.Session["User"] = null;
			return Request.CreateResponse(HttpStatusCode.OK);
		}
		
	}
}