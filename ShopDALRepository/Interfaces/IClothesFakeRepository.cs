﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;


namespace ShopDALRepository.Interfaces
{
	public interface IClothesFakeRepository : IRepository<Clothes>, IProduct, IWeareable
	{
	}
	
}
