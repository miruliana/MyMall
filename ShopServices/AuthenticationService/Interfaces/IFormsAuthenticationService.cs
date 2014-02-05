using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopServices.AuthenticationService.Interfaces
{
	public interface IFormsAuthenticationService
	{
		void SignIn(string userName, bool createPersistentCookie);
		void SignOut();
		void RedirectToLoginPage();
	}
}
