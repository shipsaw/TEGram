using Capstone.DataTransferObjects;
using Capstone.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Capstone.ApiResponseObjects
{
    public class PackagingHelper
    {
        private readonly ApplicationDbContext _context;
        public PackagingHelper(ApplicationDbContext context)
        {
            _context = context;
        }
        public UserDto PackageUser(int id, Expression<Func<Photo, bool>> predicate)
        {
            User user = _context.Users.First(u => u.UserId == id);
            UserDto data = new UserDto();
            data.UserProfileUrl = user.ProfileUrl;
            data.UserId = user.UserId;
            data.Username = user.Username;
            data.Firstname = user.FirstName;
            data.Lastname = user.LastName;
            data.Photos = PackagePhotos(predicate);

            return data;
        }

        public PhotoDto PackagePhoto(int photoId)
        {
            Photo photo = _context.Photos
                .Include(p => p.PhotoLikes)
                .Include(p => p.PhotoFavorites)
                .Include(p => p.PhotoComments)
                .ThenInclude(c => c.User)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefault(p => p.PhotoId == photoId);

            if (photo != null)
            {
                return new PhotoDto
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
        public List<PhotoDto> PackagePhotos(Expression<Func<Photo, bool>> predicate)
        {
            List<Photo> photos = _context.Photos
                .Include(p => p.PhotoLikes)
                .Include(p => p.PhotoFavorites)
                .Include(p => p.PhotoComments)
                .ThenInclude(c => c.User)
                .Where(predicate)
                .Where(p => p.IsDeleted == false)
                .OrderByDescending(p => p.CreatedDate)
                .ToList();

            List<PhotoDto> retPhotos = new List<PhotoDto>();
            foreach (var photo in photos)
            {
                retPhotos.Add(new PhotoDto
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

        public CommentDto PackageComment(Comment comment)
        {
            return new CommentDto
            {
                CommentId = comment.CommentId,
                Username = comment.User.Username,
                Content = comment.Content
            };
        }



    }
}
