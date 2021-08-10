using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DataTransferObjects
{
    public static class DtoExtMethods
    {
        public static IQueryable<UserDto> MapUserToDto(this IQueryable<User> users)
        {
            return users.Select(user => new UserDto
            {
                UserId = user.UserId,
                Username = user.Username,
                UserProfileUrl = user.ProfileUrl,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Photos = user.Photos.MapPhotoToDto().ToList()
            });
        }

        public static IQueryable<PhotoDto> MapPhotoToDto(this IQueryable<Photo> photos)
        {
            return photos.Select(photo => new PhotoDto
            {
                PhotoId = photo.PhotoId,
                Url = photo.Url,
                UserId = photo.UserId,
                //Comments = photo.PhotoComments.AsQueryable().MapCommentToDto().ToList(),
                Likes = photo.PhotoLikes.Select(p => p.UserId).ToList(),
                Favorites = photo.PhotoFavorites.Select(p => p.UserId).ToList()
            });
        }
        public static IQueryable<CommentDto> MapCommentToDto(this IQueryable<Comment> comments)
        {
            return comments.Select(comment => new CommentDto
            {
                CommentId = comment.CommentId,
                Username = comment.User.Username,
                Content = comment.Content
            });
        }
    }
}
