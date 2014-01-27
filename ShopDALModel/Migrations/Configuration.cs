namespace ShopDAL.Migrations
{
	using System;
	using System.Collections.Generic;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;
	using ShopDAL.Model;

	internal sealed class Configuration : DbMigrationsConfiguration<ShopContext>
	{
		public Configuration()
		{
			AutomaticMigrationsEnabled = false;
		}

		protected override void Seed(ShopDAL.Model.ShopContext context)
		{

			var brands = new List<Brand>
				{
					new Brand {Id = 1, Name = "Nike"},
					new Brand {Id = 2, Name = "Gucci"},
					new Brand {Id = 3, Name = "D&G"},
					new Brand {Id = 4, Name = "L'Oreal"},
					new Brand {Id = 5, Name = "Rimmel"}
				};
			brands.ForEach(s => context.Brands.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

			var productTypes = new List<ProductType>
				{
					new ProductType {Id = 1, Name = "Clothing"},
					new ProductType {Id = 2, Name = "Shoes"},
				    new ProductType {Id = 3, Name = "Accesories"},
				};
			productTypes.ForEach(s => context.ProductTypes.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

			var categories = new List<Category>
				{
					
					new Category {Id = 1, Name = "Pants"},
					new Category {Id = 2, Name = "Dresses"},
					new Category {Id = 3, Name = "Hair"},
					new Category {Id = 4, Name = "Skirts"},
					new Category {Id = 5, Name = "Boots"},
					new Category {Id = 6, Name = "Face"},
				};
			categories.ForEach(s => context.Categories.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

			var size = new List<Size>
				{
					new Size {Id = 1, Name = "XS", Unit = ""},
					new Size {Id = 2, Name = "S", Unit = ""},
					new Size {Id = 3, Name = "M", Unit = ""},
					new Size {Id = 4, Name = "L", Unit = ""},
					new Size {Id = 5, Name = "XL", Unit = ""},
					new Size {Id = 6, Name = "25", Unit = "g"},
					new Size {Id = 7, Name = "250", Unit = "ml"},
					new Size {Id = 8, Name = "500", Unit = "ml"},
					new Size {Id = 9, Name = "38", Unit = ""},
					new Size {Id = 10, Name = "39", Unit = ""},
					new Size {Id = 11, Name = "40", Unit = ""},
					new Size {Id = 12, Name = "41", Unit = ""},
				};
			size.ForEach(s => context.Sizes.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

			var colour = new List<Colour>
				{
					new Colour {Id = 1, Name = "Red"},
					new Colour {Id = 2, Name = "Green"},
					new Colour {Id = 3, Name = "Blue"},
					new Colour {Id = 4, Name = "Yellow"},
					new Colour {Id = 5, Name = "Black"}

				};
			colour.ForEach(s => context.Colours.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

			var destinations = new List<Destination>
				{
					new Destination {Id = 1, Name = "Women"},
					new Destination {Id = 2, Name = "Men"},
					new Destination {Id = 3, Name = "Kids"}
				};
			destinations.ForEach(s => context.Destinations.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

			var clothes = new List<Clothes>
				{
					new Clothes
						{
							SizeId = size.Single(s => s.Name == "M").Id,
							BrandId = brands.Single(s => s.Name == "Gucci").Id,
							DestinationId = destinations.Single(s => s.Name == "Women").Id,
							ColourId = colour.Single(s => s.Name == "Red").Id,
							Code = "10A",
							Name = "Evening dress",
							Price = 10.5,
							Colection = "Spring/Summer",
							TypeId = 1,
							CategoryId = 2 
						},
					new Clothes
						{
							SizeId = size.Single(s => s.Name == "S").Id,
							BrandId = brands.Single(s => s.Name == "D&G").Id,
							DestinationId = destinations.Single(s => s.Name == "Women").Id,
							ColourId = colour.Single(s => s.Name == "Red").Id,
							Code = "10B",
							Name = "Fancy skirt",
							Price = 15.5,
							Colection = "Spring/Summer",
							TypeId = 1,
							CategoryId = 4
						},
					new Clothes
						{
							SizeId = size.Single(s => s.Name == "40").Id,
							BrandId = brands.Single(s => s.Name == "Nike").Id,
							DestinationId = destinations.Single(s => s.Name == "Men").Id,
							ColourId = colour.Single(s => s.Name == "Blue").Id,
							Code = "10C",
							Name = "The man's shoes",
							Price = 20.5,
							Colection = "Spring/Summer",
						    TypeId = 2,
							CategoryId = 1
						}
				};
			clothes.ForEach(s => context.Clothes.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

			var cosmetic = new List<Cosmetic>
			{

			new Cosmetic { 
					
						SizeId = size.Single(s => s.Name == "25").Id, 
						BrandId = brands.Single(s => s.Name == "L'Oreal").Id, 
						DestinationId = destinations.Single(s => s.Name == "Women").Id, 
						ColourId = colour.Single(s => s.Name == "Red").Id, 
						Code = "10D",
						Name = "Lipstick",
						Price = 20.5,
						FabricationDate = DateTime.Parse("2012-09-01"),
						ExpireDate = DateTime.Parse("2014-09-01"),
						CategoryId = 6
					},
			new Cosmetic { 
						SizeId = size.Single(s => s.Name == "250").Id, 
						BrandId = brands.Single(s => s.Name == "L'Oreal").Id, 
						DestinationId = destinations.Single(s => s.Name == "Women").Id, 
						ColourId = colour.Single(s => s.Name == "Red").Id, 
						Code = "10E",
						Name = "HairColor",
						Price = 25.5,
						FabricationDate = DateTime.Parse("2011-09-01"),
						ExpireDate = DateTime.Parse("2015-09-01"),
						CategoryId = 3
					}
                
			};
			cosmetic.ForEach(s => context.Cosmetic.AddOrUpdate(p => p.Name, s));
			context.SaveChanges();

		
		  
		}
	}
}
