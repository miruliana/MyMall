using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALRepository.Interfaces;
using ShopDAL.Model;

namespace ShopDALRepository.Repositories
{
	public partial class ClothesFakeRepository : Repository<Clothes>, IClothesFakeRepository
	{
		#region Ctors
		
		public ClothesFakeRepository(ShopContext context)
			: base(context)
		{
		}
		public ClothesFakeRepository()
			: base()
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
		public void Commit()
		{
			if (base.CurrentContext != null)
			(base.CurrentContext as ShopContext).SaveChanges();
		}
		#endregion Ctors
	}
}
