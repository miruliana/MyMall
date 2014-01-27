using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDALRepository.Interfaces;
using ShopServices.Interfaces;
using ShopServices.Windsor;

namespace ShopUI.Tests.Mapping
{
	[TestClass]
	public class Windsor
	{
		[TestMethod]
		public void WindsorGetClothesRepository()
		{
			// Arrange
			WindsorService.Clear();
			WindsorService.AddAssemblyResourceInstaller("ShopServices", "WindsorConfiguration.xml");
			WindsorService.Install();
		
			// Act
			IClothesRepository clothesRepository = WindsorService.Resolve<IClothesRepository>();
			
			// Assert
			Assert.IsNotNull(clothesRepository);
			Assert.AreEqual(clothesRepository.GetType().Name, "ClothesRepository");

		}
		[TestMethod]
		public void WindsorGetCosmeticRepository()
		{
			// Arrange
			WindsorService.Clear();
			WindsorService.AddAssemblyResourceInstaller("ShopServices", "WindsorConfiguration.xml");
			WindsorService.Install();

			// Act
			ICosmeticRepository cosmeticRepository = WindsorService.Resolve<ICosmeticRepository>();
		

			// Assert
			Assert.IsNotNull(cosmeticRepository);
			Assert.AreEqual(cosmeticRepository.GetType().Name, "CosmeticRepository");

		}
		[TestMethod]
		public void WindsorGetBrandRepository()
		{
			// Arrange
			WindsorService.Clear();
			WindsorService.AddAssemblyResourceInstaller("ShopServices", "WindsorConfiguration.xml");
			WindsorService.Install();

			// Act
			IBrandRepository brandRepository = WindsorService.Resolve<IBrandRepository>();
			

			// Assert
			Assert.IsNotNull(brandRepository);
			Assert.AreEqual(brandRepository.GetType().Name, "BrandRepository");

		}
		[TestMethod]
		public void WindsorGetClothesService()
		{
			// Arrange
			WindsorService.Clear();
			WindsorService.AddAssemblyResourceInstaller("ShopServices", "WindsorConfiguration.xml");
			WindsorService.Install();

			// Act
			IClothesService clothesServiceBase = WindsorService.Resolve<IClothesService>(WindsorService.Resolve<IClothesRepository>());
			

			// Assert
			Assert.IsNotNull(clothesServiceBase);
			Assert.AreEqual(clothesServiceBase.GetType().Name, "ClothesService");

		}
		[TestMethod]
		public void WindsorGetCosmeticService()
		{
			// Arrange
			WindsorService.Clear();
			WindsorService.AddAssemblyResourceInstaller("ShopServices", "WindsorConfiguration.xml");
			WindsorService.Install();

			// Act
			ICosmeticService cosmeticServiceBase = WindsorService.Resolve<ICosmeticService>(WindsorService.Resolve<ICosmeticRepository>());
			

			// Assert
			Assert.IsNotNull(cosmeticServiceBase);
			Assert.AreEqual(cosmeticServiceBase.GetType().Name, "CosmeticService");

		}
		[TestMethod]
		public void WindsorGetBrandService()
		{
			// Arrange
			WindsorService.Clear();
			WindsorService.AddAssemblyResourceInstaller("ShopServices", "WindsorConfiguration.xml");
			WindsorService.Install();

			// Act
			IBrandService brandServiceBase = WindsorService.Resolve<IBrandService>(WindsorService.Resolve<IBrandRepository>());

			// Assert
			Assert.IsNotNull(brandServiceBase);
			Assert.AreEqual(brandServiceBase.GetType().Name, "BrandService");

		}
	}
}
