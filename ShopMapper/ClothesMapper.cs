using ShopDAL.Model;
using ShopDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ShopMapper
{
    public class ClothesMapper
    {
        public static ClothesDTO ClothesToClothesDto(Clothes entity)
        {
	        Mapper.CreateMap<Clothes, ClothesDTO>();
            if (entity != null)
            {
	            ClothesDTO  clothesDto = Mapper.Map<Clothes, ClothesDTO>(entity);
	            return clothesDto;
            }
            return null;
        }

		public static Clothes ClothesDtoToClothes(ClothesDTO clothesDto)
        {
			Mapper.CreateMap<ClothesDTO, Clothes>();
			if (clothesDto != null)
			{
				Clothes clothes = Mapper.Map<ClothesDTO, Clothes>(clothesDto);
				return clothes;
			}
			return null;
        }

		public static IQueryable<ClothesDTO> ClothesToClothesDtoList(IQueryable<Clothes> clothes)
		{
			var select = from product in clothes
						 select new ClothesDTO
						 {
							 Id = product.Id,
							 Code = product.Code,
							 Name = product.Name,
							 Price = product.Price,
							 BrandId = product.BrandId,
							 CategoryId = product.CategoryId
						 };
			return select;
		}
    }
}
