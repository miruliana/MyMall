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
		[TestInitialize]
		public void InstallWindsor()
		{
			WindsorService.Clear();
			WindsorService.AddAssemblyResourceInstaller("ShopServices", "WindsorConfiguration.xml");
			WindsorService.Install();
		}
		[TestMethod]
		public void WindsorGetClothesRepository()
		{
			// Arrange
		
			// Act
			IClothesRepository clothesRepository = WindsorService.Resolve<IClothesRepository>();
			
			// Assert
			Assert.IsNotNull(clothesRepository);
			Assert.IsInstanceOfType(clothesRepository, typeof(IClothesRepository));

		}
		[TestMethod]
		public void WindsorGetCosmeticRepository()
		{
			// Arrange
			
			// Act
			ICosmeticRepository cosmeticRepository = WindsorService.Resolve<ICosmeticRepository>();
		

			// Assert
			Assert.IsNotNull(cosmeticRepository);
			Assert.IsInstanceOfType(cosmeticRepository, typeof(ICosmeticRepository));

		}
		[TestMethod]
		public void WindsorGetBrandRepository()
		{
			// Arrange
			
			// Act
			IBrandRepository brandRepository = WindsorService.Resolve<IBrandRepository>();
			

			// Assert
			Assert.IsNotNull(brandRepository);
			Assert.IsInstanceOfType(brandRepository, typeof(IBrandRepository));

		}
		[TestMethod]
		public void WindsorGetClothesService()
		{
			// Arrange
		
			// Act
			IClothesService clothesServiceBase = WindsorService.Resolve<IClothesService>(WindsorService.Resolve<IClothesRepository>());
			

			// Assert
			Assert.IsNotNull(clothesServiceBase);
			Assert.IsInstanceOfType(clothesServiceBase, typeof(IClothesService));

		}
		[TestMethod]
		public void WindsorGetCosmeticService()
		{
			// Arrange
		
			// Act
			ICosmeticService cosmeticServiceBase = WindsorService.Resolve<ICosmeticService>(WindsorService.Resolve<ICosmeticRepository>());
			

			// Assert
			Assert.IsNotNull(cosmeticServiceBase);
			Assert.IsInstanceOfType(cosmeticServiceBase, typeof(ICosmeticService));

		}
		[TestMethod]
		public void WindsorGetBrandService()
		{
			// Arrange
			
			// Act
			IBrandService brandServiceBase = WindsorService.Resolve<IBrandService>(WindsorService.Resolve<IBrandRepository>());

			// Assert
			Assert.IsNotNull(brandServiceBase);
			Assert.IsInstanceOfType(brandServiceBase, typeof(IBrandService));

		}
	}
}
