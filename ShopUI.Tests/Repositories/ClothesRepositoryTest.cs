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
using Moq;
using System.Linq.Expressions;


namespace ShopUI.Tests.Repositories
{
	[TestClass]
	public class ClothesRepositoryTest
	{

		public List<Clothes> GetClothesList()
		{
			List<Clothes> clothes = new List<Clothes>
                {
                    new Clothes { Id = 1, Code = "A", Name = "Skirt", Price = 10.5},
                    new Clothes { Id = 2, Code = "B", Name = "Dress", Price = 59.99 },
                    new Clothes { Id = 3, Code = "C", Name = "Pants", Price = 29.99 }
                };
			return clothes;
		}
		public Clothes GetNewProduct()
		{
			Clothes clotheProduct = new Clothes();
			clotheProduct.Code = "Blah";
			clotheProduct.Name = "Test Blah";
			clotheProduct.Price = 55;
			return clotheProduct;
		}

		
		[TestMethod]
		public void Get()
		{
			// Arrange
			List<Clothes> clothes = GetClothesList();
			Mock<IClothesRepository> mockClothesRepository = new Mock<IClothesRepository>();
			mockClothesRepository.Setup(mr => mr.Get(It.IsAny<Expression<Func<Clothes, bool>>>(), It.IsAny<Func<IQueryable<Clothes>, IOrderedQueryable<Clothes>>>(), "")).Returns(clothes.AsQueryable());
			// Act
			IEnumerable<Clothes> clothesList = mockClothesRepository.Object.Get(null, q => q.OrderBy(d => d.Id)).ToList();
		
			// Assert
			Assert.IsNotNull(clothesList);
			Assert.IsTrue(clothesList.Count() == 3);
		}

		[TestMethod]
		public void GetById()
		{
			// Arrange
			// Arrange
			List<Clothes> clothes = GetClothesList();
			Mock<IClothesRepository> mockClothesRepository = new Mock<IClothesRepository>();
			mockClothesRepository.Setup(mr => mr.GetById(It.IsAny<int>())).Returns((int i) => clothes.Where(x => x.Id == i).Single());
			
			// Act
			Clothes clothesObject = mockClothesRepository.Object.GetById(2);
			// Assert
			Assert.AreEqual(2, clothesObject.Id);
			Assert.AreEqual("B", clothesObject.Code);
			Assert.AreEqual("Dress", clothesObject.Name);
			Assert.AreEqual(59.99, clothesObject.Price);
		}

		[TestMethod]
		public void Post()
		{
			List<Clothes> clothes = GetClothesList();
			Mock<IClothesRepository> mockClothesRepository = new Mock<IClothesRepository>();
			Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
			mockClothesRepository.Setup(mr => mr.Insert(It.IsAny<Clothes>()));
			
			
			mockUnitOfWork.Setup(uw => uw.Commit());
			// Act
			Clothes product = GetNewProduct();
			mockClothesRepository.Object.Insert(product);
			mockUnitOfWork.Object.Commit();
			int productCount = mockClothesRepository.Object.Get(null, q => q.OrderBy(d => d.Id)).Count();
		
			// Assert
			Assert.IsNotNull(product.Id);
			Assert.AreNotEqual(product.Id, 0);
			Assert.AreEqual(product.Id, (productCount + 1));
		}

		[TestMethod]
		public void Put()
		{
			// Arrange
		
			ClothesFakeRepository fakeRepo = new ClothesFakeRepository();
			Clothes clothes = new Clothes();
			clothes.Id = 25;
			clothes.Code = "10B";
			clothes.Name = "Fancy skirt 10";
		
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
