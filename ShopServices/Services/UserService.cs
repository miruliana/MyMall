using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopDAL.Model;
using ShopDALModel.Model;
using ShopDALRepository.Interfaces;
using ShopDTO;
using ShopMapper;
using ShopServices.Interfaces;

namespace ShopServices.Services
{
	public class UserService : Service<User>, IUserService
	{
		public UserService(IRepository<User> baseRepository) : base(baseRepository) { }
		public IQueryable<UserDTO> GetAll()
		{
			IQueryable<User> users = base.Get(null, q => q.OrderBy(d => d.Id));
			IQueryable<UserDTO> usersDtoList = UserMapper.UserToUserDtoList(users);
			return usersDtoList;
		}
		

		public UserDTO Insert(UserDTO userDto)
		{
			userDto = UserMapper.UserToUserDto(base.Insert(UserMapper.UserDtoToUser(userDto)));
			return userDto;
		}

		public UserDTO GetUser(string userName)
		{
			var user = base.Get(u => u.Name == userName, q => q.OrderBy(d => d.Id)).SingleOrDefault();
			return UserMapper.UserToUserDto(user);
		}

		public UserDTO GetUser(string userName, string password)
		{
			var user = base.Get(u => (u.Name == userName && u.Password == password), q => q.OrderBy(d => d.Id)).SingleOrDefault();
			return UserMapper.UserToUserDto(user);
		}
	}
}
