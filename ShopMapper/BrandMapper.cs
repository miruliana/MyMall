using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using ShopDAL.Model;
using ShopDTO;

namespace ShopMapper
{

	public class BrandMapper 
	{
		
		public static BrandDTO BrandToBrandDto(Brand entity)
		{
			Mapper.CreateMap<Brand, BrandDTO>();
			if (entity != null)
			{
				BrandDTO brandDto = Mapper.Map<Brand, BrandDTO>(entity);
				return brandDto;
			}
			return null;
		}
		public static Brand BrandDtoToBrand(BrandDTO brandDto)
		{
			Mapper.CreateMap<BrandDTO, Brand>();
			if (brandDto != null)
			{
				Brand brand = Mapper.Map<BrandDTO, Brand>(brandDto);
				return brand;
			}
			return null;
		}
		public static IQueryable<BrandDTO> BrandToBrandDtoList(IQueryable<Brand> brands)
		{
			var select = from brand in brands
						 select new BrandDTO
						 {
							 Id = brand.Id,
							 Name = brand.Name
						 };
			return select;
		}

	}
}
