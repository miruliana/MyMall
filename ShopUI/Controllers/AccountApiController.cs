using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
					return Request.CreateResponse(HttpStatusCode.OK);
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
			return Request.CreateResponse(HttpStatusCode.OK);
		}
		
	}
}