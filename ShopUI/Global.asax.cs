using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using ShopServices.Services;
using ShopServices.Windsor;


namespace ShopUI
{
	public class Global : HttpApplication
	{
		void Application_Start(object sender, EventArgs e)
		{
			// Code that runs on application startup
			BundleConfig.RegisterBundles(BundleTable.Bundles);
			AuthConfig.RegisterOpenAuth();
			RouteTable.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional }
				);
			RouteTable.Routes.MapHttpRoute(
				name: "LoginApi",
				routeTemplate: "api/AccountApi/LogIn/{id}",
				defaults: new { id = RouteParameter.Optional }
				);
			InstallWindsor();
		
		}
		
		public void InstallWindsor()
		{
			WindsorService.Clear();
			WindsorService.AddAssemblyResourceInstaller("ShopServices", "WindsorConfiguration.xml"); 
			WindsorService.Install();
		}
	
		void Application_End(object sender, EventArgs e)
		{
			//  Code that runs on application shutdown
		}

		void Application_Error(object sender, EventArgs e)
		{
			// Code that runs when an unhandled error occurs

		}
	}
}
