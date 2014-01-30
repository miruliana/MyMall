using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ShopDAL.Model;
using ShopDTO;

namespace ShopMapper
{
	public class CategoriesMapper
	{

		public static CategoriesDTO CategoryToCategoryDto(Category entity)
		{
			Mapper.CreateMap<Category, CategoriesDTO>();
			if (entity != null)
			{
				CategoriesDTO categoryDto = Mapper.Map<Category, CategoriesDTO>(entity);
				return categoryDto;
			}
			return null;
		}
		public static Category CategoryDtoToCategory(CategoriesDTO categoryDto)
		{
			Mapper.CreateMap<CategoriesDTO, Category>();
			if (categoryDto != null)
			{
				Category category = Mapper.Map<CategoriesDTO, Category>(categoryDto);
				return category;
			}
			return null;
		}
		public static IQueryable<CategoriesDTO> CategoryToCategoryDtoList(IQueryable<Category> categories)
		{
			var select = from category in categories
						 select new CategoriesDTO
						 {
							 Id = category.Id,
							 Name = category.Name
						 };
			return select;
		}

	}
}
