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
    public class CosmeticMapper
    {
		public static CosmeticDTO CosmeticToCosmeticDto(Cosmetic entity)
		{
			Mapper.CreateMap<Cosmetic, CosmeticDTO>();
			if (entity != null)
			{
				CosmeticDTO cosmeticDto = Mapper.Map<Cosmetic, CosmeticDTO>(entity);
				return cosmeticDto;
			}
			return null;
		}

		public static Cosmetic CosmeticDtoToCosmetic(CosmeticDTO cosmeticDto)
		{
			Mapper.CreateMap<CosmeticDTO, Cosmetic>();
			if (cosmeticDto != null)
			{
				Cosmetic cosmetic = Mapper.Map<CosmeticDTO, Cosmetic>(cosmeticDto);
				return cosmetic;
			}
			return null;
		}
    }
}
