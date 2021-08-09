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

        public PhotoDataResponse PackagePhoto(int photoId)
        {
            Photo photo = _context.Photos
                .Include(p => p.PhotoLikes)
                .Include(p => p.PhotoFavorites)
                .Include(p => p.PhotoComments)
                .ThenInclude(c => c.User)
                .FirstOrDefault(p => p.PhotoId == photoId);

            if (photo != null)
            {
                return new PhotoDataResponse
                {
                    PhotoId = photo.PhotoId,
                    Url = photo.Url,
                    UserId = photo.UserId,
                    Comments = photo.PhotoComments.Select(c => PackageComment(c)).ToList(),
                    //Comments = null,
                    Likes = photo.PhotoLikes.Select(p => p.UserId).ToList(),
                    Favorites = photo.PhotoFavorites.Select(p => p.UserId).ToList()
                };
            }
            else
            {
                return null;
            }

        }
        public List<PhotoDataResponse> PackagePhotos(Expression<Func<Photo, bool>> predicate)
        {
            List<Photo> photos = _context.Photos
                .Include(p => p.PhotoLikes)
                .Include(p => p.PhotoFavorites)
                .Include(p => p.PhotoComments)
                .ThenInclude(c => c.User)
                .Where(predicate)
                .OrderByDescending(p => p.CreatedDate)
                .ToList();

            List<PhotoDataResponse> retPhotos = new List<PhotoDataResponse>();
            foreach (var photo in photos)
            {
                retPhotos.Add(new PhotoDataResponse
                {
                    PhotoId = photo.PhotoId,
                    Url = photo.Url,
                    UserId = photo.UserId,
                    Comments = photo.PhotoComments.Select(c => PackageComment(c)).ToList(),
                    //Comments = null,
                    Likes = photo.PhotoLikes.Select(p => p.UserId).ToList(),
                    Favorites = photo.PhotoFavorites.Select(p => p.UserId).ToList()
                });

            }
            return retPhotos;
        }

        public CommentDataResponse PackageComment(Comment comment)
        {
            return new CommentDataResponse
            {
                CommentId = comment.CommentId,
                Username = comment.User.Username,
                Content = comment.Content
            };
        }



    }
}
