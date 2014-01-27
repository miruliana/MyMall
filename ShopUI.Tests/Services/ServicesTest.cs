using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDTO;
using ShopServices.Services;

namespace ShopUI.Tests.Services
{
	[TestClass]
	public class ServicesTest
	{
		public ServicesManager Services
		{
			get { return ServicesManager.Instance; }
		}
		
		[TestMethod]
		public void Service()
		{
			//Arrange
		
			//Act
			IEnumerable<ClothesDTO> clothes = Services.ClothesService.GetAll();

			//Assert
		}
	}
}
