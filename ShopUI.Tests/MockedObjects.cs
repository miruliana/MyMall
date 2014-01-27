using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Moq;
using ShopServices.Services;

namespace ShopUI.Tests
{
	public class MockedObjects
	{
		public ServicesManager GetServicesManagerInstance()
		{
			var context = new Mock<HttpContextBase>();
			ServicesManager manager = new ServicesManager();
			SetCurrentContext(manager);
			return manager;
		}

		private void SetCurrentContext(ServicesManager manager)
		{
			var context = new Mock<HttpContextBase>();
			var httpContextKey = ConfigurationManager.AppSettings["HTTPCONTEXTKEY"];
			context.Setup(ctx => ctx.Items.Add(httpContextKey, manager));
			HttpContextFactory.SetCurrentContext(context.Object);
		}
	}
}
