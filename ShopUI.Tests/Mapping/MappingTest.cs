using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDAL.Model;
using ShopMapper;
using ShopDALRepository.Repositories;
using ShopDTO;
using ShopUI;



namespace ShopUI.Tests.Mapping
{
	[TestClass]
	public class MappingTest
	{
		[TestMethod]
		public void ClothesToClothesDtoMappingTest()
		{
			// Arrange
			Clothes clothes = new Clothes();
			clothes.Id = 35;
			clothes.Code = "A";
			clothes.Name = "Test";
			clothes.Price = 10;
			// Act
			ClothesDTO clothesDTO = ClothesMapper.ClothesToClothesDto(clothes);

			// Assert
			Assert.AreEqual(clothes.Id, clothesDTO.Id);
			Assert.AreEqual(clothes.Code, clothesDTO.Code);
			Assert.AreEqual(clothes.Name, clothesDTO.Name);
			Assert.AreEqual(clothes.Price, clothesDTO.Price);
		}

		[TestMethod]
		public void ClothesDtoToClothesMappingTest()
		{
			// Arrange
			ClothesDTO clothesDTO = new ClothesDTO();
			clothesDTO.Id = 35;
			clothesDTO.Code = "A";
			clothesDTO.Name = "Test";
			clothesDTO.Price = 10;
			// Act
			Clothes clothes = ClothesMapper.ClothesDtoToClothes(clothesDTO);

			// Assert
			Assert.AreEqual(clothes.Id, clothesDTO.Id);
			Assert.AreEqual(clothes.Code, clothesDTO.Code);
			Assert.AreEqual(clothes.Name, clothesDTO.Name);
			Assert.AreEqual(clothes.Price, clothesDTO.Price);
		}
	}
}
