using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDAL.Model;
using ShopDALRepository.Repositories;
using ShopDTO;
using ShopUI;



namespace ShopUI.Tests.Controllers
{
	[TestClass]
	public class ClothesApiControllerTest
	{
		//[TestMethod]
		//public void Get()
		//{
		//	// Arrange
		//	ClothesApiController controller = new ClothesApiController();

		//	// Act
		//	IEnumerable<ClothesDTO> result = controller.Get();

		//	// Assert
		//	Assert.IsNotNull(result);
		//	Assert.AreEqual(3, result.Count());
		//}

		[TestMethod]
		public void GetById()
		{
			// Arrange
		//	ClothesApiController controller = new ClothesApiController();
		
			// Act
			//ClothesDTO clothesDTO = controller.GetById(5);
		
			// Assert
		
		}

		//[TestMethod]
		//public void Post()
		//{
		//	// Arrange
		//	ClothesApiController controller = new ClothesApiController();
		//	ClothesDTO clothesDTO = new ClothesDTO();
		//	clothesDTO.Code = "A";
		//	clothesDTO.Name = "Test";
		//	// Act
		//	controller.Post(clothesDTO);

		//	// Assert
		//}

		[TestMethod]
		public void Put()
		{
			// Arrange
		//	ClothesApiController controller = new ClothesApiController();
		//	ClothesDTO clothesDTO = new ClothesDTO();
		//	clothesDTO.Code = "A";
		//	clothesDTO.Name = "Test";
		
		//	// Act
		//	controller.Put(5, clothesDTO);
		
		//	// Assert
		}

		[TestMethod]
		public void Delete()
		{
			// Arrange
			//ClothesApiController controller = new ClothesApiController();
			
		
			// Act
			//controller.Delete(5);
			

			// Assert
		}
	}
}
