using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;

namespace ShopDALRepository.Repositories
{
	public partial class ClothesRepository : Repository<Clothes>, IClothesRepository
	{
		#region Ctors
		
        public ClothesRepository(ShopContext context)
            : base(context)
        {
        }
		public ClothesRepository()
		{
			
		}
		public string GetName(object id)
		{
			Clothes entity = base.GetById(id);
			return entity.Name;
		}
		public double GetPrice(object id)
		{
			Clothes entity = base.GetById(id);
			return entity.Price;
		}
		public string GetCollection(object id)
		{
			Clothes entity = base.GetById(id);
			return entity.Colection;
		}
		#endregion Ctors
	}
}
