using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ShopDTO;
using ShopServices.Interfaces;
using ShopServices.Services;

namespace ShopUI.Tests.Services
{
	[TestClass]
	public class ServicesTest
	{
		[TestMethod]
		public void ClothesServiceTest()
		{
			//Arrange
			MockedObjects mocking = new MockedObjects();
			//Act
			ClothesService clothesService = mocking.GetServicesManagerInstance().ClothesService;
			//Assert
			Assert.IsNotNull(clothesService);
			Assert.IsInstanceOfType(clothesService, typeof(IClothesService));
		}

		[TestMethod]
		public void CosmeticServiceTest()
		{
			//Arrange
			MockedObjects mocking = new MockedObjects();
			//Act
			CosmeticService cosmeticService = mocking.GetServicesManagerInstance().CosmeticService;
			//Assert
			Assert.IsNotNull(cosmeticService);
			Assert.IsInstanceOfType(cosmeticService, typeof(ICosmeticService));
		}

		[TestMethod]
		public void BrandServiceTest()
		{
			//Arrange
			MockedObjects mocking = new MockedObjects();
			//Act
			BrandService brandService = mocking.GetServicesManagerInstance().BrandService;
			//Assert
			Assert.IsNotNull(brandService);
			Assert.IsInstanceOfType(brandService, typeof(IBrandService));
		}
	}
}
