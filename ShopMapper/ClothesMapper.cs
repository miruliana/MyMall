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

		public static IEnumerable<ClothesDTO> ClothesToClothesDtoList(IEnumerable<Clothes> clothes)
		{
			List<ClothesDTO> clothesDToList = new List<ClothesDTO>();
			foreach (var cloth in clothes)
			{
				if (cloth != null)
				{
					ClothesDTO clothesDTO = ClothesToClothesDto(cloth);
				    clothesDToList.Add(clothesDTO);
				}
			}
			
			return clothesDToList.AsEnumerable();
		}
    }
}
