using Capstone.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Capstone.Controllers
{
    public class ControllerHelper
    {
        // Helper function to grab all the photo data for the returned user
        public static User AddDataToUser(ApplicationDbContext context, int userId)
        {
            var user = context.Users
                .Where(u => u.IsDeleted == false)
                .FirstOrDefault(u => u.UserId == userId);

                context.Entry(user)
                    .Collection(user => user.Photos)
                    .Query()
                    .Where(p => p.IsDeleted == false)
                    .Load();

            foreach (var photo in user.Photos)
            {
                context.Entry(photo).Collection(photo => photo.PhotoComments).Load();
                context.Entry(photo).Collection(photo => photo.PhotoFavorites).Load();
                context.Entry(photo).Collection(photo => photo.PhotoLikes).Load();
            }
            return user;
    }

}
}
