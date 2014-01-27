using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;
using ShopDALRepository.Repositories;
using ShopDTO;
using ShopServices.Windsor;
using ShopUI;
using ShopDALModel.BaseModel;
using ShopServices.Interfaces;
using ShopMapper;
using ShopServices.Services;



namespace ShopUI.Tests.Repositories
{
	[TestClass]
	public class RepositoryTest
	{
		


		[TestMethod]
		public void Get()
		{
			// Arrange
			ClothesFakeRepository fakeRepo = new ClothesFakeRepository();

			// Act
			IEnumerable<Clothes> clothesList = fakeRepo.Get(null, q => q.OrderBy(d => d.Id)).ToList();
			// Assert
		
		}

		[TestMethod]
		public void GetById()
		{
			// Arrange
		
			ClothesFakeRepository fakeRepo = new ClothesFakeRepository();
			// Act
			Clothes clothes = fakeRepo.GetById(25);
			// Assert
			Assert.AreEqual("10B", clothes.Code);
		}

		[TestMethod]
		public void Post()
		{
			// Arrange
			ClothesFakeRepository fakeRepo = new ClothesFakeRepository();
			Clothes clothes = new Clothes();
			clothes.Id = 35;
			clothes.Code = "A";
			clothes.Name = "Test";
			// Act
			fakeRepo.Insert(clothes);
			fakeRepo.Commit();

			// Assert
			Assert.IsNotNull(clothes.Id);
			Assert.AreNotEqual(clothes.Id, 0);
		}

		[TestMethod]
		public void Put()
		{
			// Arrange
		
			ClothesFakeRepository fakeRepo = new ClothesFakeRepository();
			Clothes clothes = new Clothes();
			clothes.Id = 35;
			clothes.Code = "A";
			clothes.Name = "Test";
		
	     	// Act
			fakeRepo.Update(clothes);
			fakeRepo.Commit();
		
			// Assert
		}

		[TestMethod]
		public void Delete()
		{
			// Arrange
		
			ClothesFakeRepository fakeRepo = new ClothesFakeRepository();
		
			// Act
			
			fakeRepo.Delete(44);
			fakeRepo.Commit();

			// Assert
		}
	}
}
