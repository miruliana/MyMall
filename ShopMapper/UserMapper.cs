using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ShopDAL.Model;
using ShopDALModel.Model;
using ShopDTO;

namespace ShopMapper
{
	public class UserMapper
	{
		public static UserDTO UserToUserDto(User entity)
		{
			Mapper.CreateMap<User, UserDTO>();
			if (entity != null)
			{
				UserDTO userDto = Mapper.Map<User, UserDTO>(entity);
				return userDto;
			}
			return null;
		}

		public static User UserDtoToUser(UserDTO userDto)
		{
			Mapper.CreateMap<UserDTO, User>();
			if (userDto != null)
			{
				User user = Mapper.Map<UserDTO, User>(userDto);
				return user;
			}
			return null;
		}

		public static IQueryable<UserDTO> UserToUserDtoList(IQueryable<User> users)
		{
			var select = from user in users
						 select new UserDTO
						 {
							 Id = user.Id,
							 Name = user.Name,
							 Password = user.Password,
							 UserEmailAddress = user.UserEmailAddress
						 };
			return select;
		}
	}
}
