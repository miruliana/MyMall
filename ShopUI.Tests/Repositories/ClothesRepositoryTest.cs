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
			// Arrange
			List<Clothes> clothes = GetClothesList();
			Mock<IClothesRepository> mockClothesRepository = new Mock<IClothesRepository>();
			Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
			mockClothesRepository.Setup(mr => mr.Insert(It.IsAny<Clothes>())).Callback((Clothes target) =>
			{
					target.Id = clothes.Count() + 1;
					clothes.Add(target);
			});
			mockUnitOfWork.Setup(uw => uw.Commit());
			// Act
			Clothes product = GetNewProduct();
			mockClothesRepository.Object.Insert(product);
			mockUnitOfWork.Object.Commit();
		
			// Assert
			Assert.IsNotNull(product.Id);
			Assert.AreNotEqual(product.Id, 0);
			Assert.AreEqual(product.Id, clothes.Count());
		}

		[TestMethod]
		public void Put()
		{
			// Arrange
			List<Clothes> clothes = GetClothesList();
			Mock<IClothesRepository> mockClothesRepository = new Mock<IClothesRepository>();
			Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
			mockClothesRepository.Setup(mr => mr.Update(It.IsAny<Clothes>())).Callback((Clothes target) =>
			{
				var original = clothes.Where(q => q.Id == target.Id).Single();
				original.Code = target.Code;
				original.Name = target.Name;
				original.Price = target.Price;
			
			});
			// Act
			Clothes product = new Clothes();
			if (clothes.Count >= 1)
			{
				product.Id = 1;
				product.Code = "AAB";
				product.Name = "Test name";
				product.Price = 15;
			}
			mockClothesRepository.Object.Update(product);
			mockUnitOfWork.Setup(uw => uw.Commit());	 
			
			// Assert
			Assert.IsNotNull(product);
			Assert.AreEqual(clothes[0].Code, "AAB");
			Assert.AreEqual(clothes[0].Name, "Test name");
			Assert.AreEqual(clothes[0].Price, 15);
		}

		[TestMethod]
		public void Delete()
		{
			// Arrange

			List<Clothes> clothes = GetClothesList();
			Mock<IClothesRepository> mockClothesRepository = new Mock<IClothesRepository>();
			Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
			mockClothesRepository.Setup(mr => mr.Delete(It.IsAny<Clothes>())).Callback((Clothes target) =>
			{
				var product = clothes.Where(q => q.Id == target.Id).Single();
				clothes.Remove(product);
			});
			mockUnitOfWork.Setup(uw => uw.Commit());
			Clothes productToDelete = new Clothes();
			productToDelete.Id = 1;
			productToDelete.Code = "A";
			productToDelete.Name = "Skirt";
			productToDelete.Price = 10.5;
			// Act
			mockClothesRepository.Object.Delete(productToDelete);
			mockUnitOfWork.Setup(uw => uw.Commit());	 
			
			// Assert
			Assert.IsFalse(clothes.Contains(productToDelete));
		}

		[TestMethod]
		public void DeleteById()
		{
			// Arrange
			List<Clothes> clothes = GetClothesList();
			Clothes productToDelete = clothes.Where(c => (c.Id == 1)).Single();
			Mock<IClothesRepository> mockClothesRepository = new Mock<IClothesRepository>();
			Mock<IUnitOfWork> mockUnitOfWork = new Mock<IUnitOfWork>();
			mockClothesRepository.Setup(mr => mr.Delete(It.IsAny<object>())).Callback((object id) =>
			{
				if (id is int)
				{
					var product = clothes.Where(q => q.Id == (int)id).Single();
					clothes.Remove(product);
				}
			});
			mockUnitOfWork.Setup(uw => uw.Commit());

			// Act
			mockClothesRepository.Object.Delete(1);
			mockUnitOfWork.Setup(uw => uw.Commit());	 

			// Assert

			Assert.IsFalse(clothes.Contains(productToDelete));
		}
	}
}
