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
        public UserDataResponse PackageUser(int id, Expression<Func<Photo, bool>> predicate)
        {
            User user = _context.Users.Where(u => u.IsDeleted == false).FirstOrDefault(u => u.UserId == id);
            if (user == null)
                return null;

            UserDataResponse data = new()
            {
                UserProfileUrl = user.ProfileUrl,
                UserId = user.UserId,
                Username = user.Username,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Photos = PackagePhotos(predicate)
            };

            return data;
        }

        public PhotoDataResponse PackagePhoto(int photoId)
        {
            Photo photo = _context.Photos
                .Include(p => p.PhotoLikes)
                .Include(p => p.PhotoFavorites)
                .Include(p => p.PhotoComments)
                .ThenInclude(c => c.User)
                .Where(p => p.IsDeleted == false)
                .FirstOrDefault(p => p.PhotoId == photoId);

            if (photo == null)
                return null;

            return new PhotoDataResponse
            {
                PhotoId = photo.PhotoId,
                Url = photo.Url,
                UserId = photo.UserId,
                Comments = photo.PhotoComments.Select(c => PackageComment(c)).ToList(),
                Likes = photo.PhotoLikes.Select(p => p.UserId).ToList(),
                Favorites = photo.PhotoFavorites.Select(p => p.UserId).ToList()
            };
        }
        public List<PhotoDataResponse> PackagePhotos(Expression<Func<Photo, bool>> predicate)
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
