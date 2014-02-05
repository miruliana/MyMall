using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALModel.Model;
using ShopDALRepository.Interfaces;

namespace ShopDALRepository.Repositories
{
	public class UserRepository : Repository<User>, IUserRepository
	{

	}
}
