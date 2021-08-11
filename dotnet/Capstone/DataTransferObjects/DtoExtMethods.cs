using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.DataTransferObjects
{
    public static class DtoExtMethods
    {
        public static IQueryable<UserDto> MapUserQueryToDto(this IQueryable<User> users) => users.Select(u => u.MapUserToDto());
        public static IEnumerable<UserDto> MapUserListToDto(this IEnumerable<User> users) => users.Select(u => u.MapUserToDto());
        public static UserDto MapUserToDto(this User user)
        {
            return new()
            {
                UserId = user.UserId,
                Username = user.Username,
                UserProfileUrl = user.ProfileUrl,
                Firstname = user.FirstName,
                Lastname = user.LastName,
                Photos = user.Photos.OrderByDescending(p => p.CreatedDate).MapPhotoListToDto().ToList()
            };
        }

        public static IQueryable<PhotoDto> MapPhotoQueryToDto(this IQueryable<Photo> photos) => photos.Select(photo => photo.MapPhotoToDto());
        public static IEnumerable<PhotoDto> MapPhotoListToDto(this IEnumerable<Photo> photos) => photos.Select(photo => photo.MapPhotoToDto());
        public static PhotoDto MapPhotoToDto(this Photo photo)
        {
                return new PhotoDto
                {
                    PhotoId = photo.PhotoId,
                    Url = photo.Url,
                    UserId = photo.UserId,
                    Comments = photo.PhotoComments.MapCommentListToDto().ToList(),
                    Likes = photo.PhotoLikes.Select(p => p.UserId).ToList(),
                    Favorites = photo.PhotoFavorites.Select(p => p.UserId).ToList()
                };
        }
        public static IQueryable<CommentDto> MapCommentQueryToDto(this IQueryable<Comment> comments) => comments.Select(c => c.MapCommentToDto());
        public static IEnumerable<CommentDto> MapCommentListToDto(this IEnumerable<Comment> comments) => comments.Select(c => c.MapCommentToDto());
        public static CommentDto MapCommentToDto(this Comment comment)
        {
                return new()
                {
                    CommentId = comment.CommentId,
                    Username = comment.User.Username,
                    Content = comment.Content
                };
        }
    }
}
