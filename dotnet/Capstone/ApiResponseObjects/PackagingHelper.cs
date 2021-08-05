using Capstone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Capstone.ApiResponseObjects
{
    public class PackagingHelper
    {
        private readonly ApplicationDbContext _context;
        public PackagingHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public UserDataResponse PackageUser(int id, Expression<Func<Photo, bool>> predicate)
        {
            User user = _context.Users.First(u => u.UserId == id);
            UserDataResponse data = new UserDataResponse();
            data.UserProfileUrl = user.ProfileUrl;
            data.UserId = user.UserId;
            data.Username = user.Username;
            data.Firstname = user.FirstName;
            data.Lastname = user.LastName;
            data.Photos = PackagePhotos(predicate);

            return data;
        }
        public List<PhotoDataResponse> PackagePhotos(Expression<Func<Photo, bool>> predicate)
        {
            List<Photo> photos = _context.Photos.Where(predicate).OrderByDescending(p => p.CreatedDate).ToList();
            List<PhotoDataResponse> retPhotos = new List<PhotoDataResponse>();
            foreach (var photo in photos)
            {
                retPhotos.Add(new PhotoDataResponse
                {
                    Url = photo.Url,
                    UserId = photo.UserId,
                    Comments = null,
                    Likes = null
                });

            }
            return retPhotos;
        }

    }
}
