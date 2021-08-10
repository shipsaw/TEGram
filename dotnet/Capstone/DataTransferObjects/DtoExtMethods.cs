using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DataTransferObjects
{
    public static class DtoExtMethods
    {
        public static IQueryable<UserDto> MapUserToDto(this IQueryable<UserDto> users)
        {
            return users.Select(user => new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                UserProfileUrl = user.UserProfileUrl,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Photos = user.Photos.ToList()
            });
        }
    }
}
