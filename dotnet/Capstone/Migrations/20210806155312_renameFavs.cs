using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class renameFavs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Photos_UserLikesPhotoId",
                table: "PhotoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Users_PhotoLikesUserId",
                table: "PhotoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser1_Photos_FavPhotosPhotoId",
                table: "PhotoUser1");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser1_Users_UsersFavoritedUserId",
                table: "PhotoUser1");

            migrationBuilder.RenameColumn(
                name: "UsersFavoritedUserId",
                table: "PhotoUser1",
                newName: "UserLikesPhotoId");

            migrationBuilder.RenameColumn(
                name: "FavPhotosPhotoId",
                table: "PhotoUser1",
                newName: "PhotoLikesUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoUser1_UsersFavoritedUserId",
                table: "PhotoUser1",
                newName: "IX_PhotoUser1_UserLikesPhotoId");

            migrationBuilder.RenameColumn(
                name: "UserLikesPhotoId",
                table: "PhotoUser",
                newName: "UserFavoritesPhotoId");

            migrationBuilder.RenameColumn(
                name: "PhotoLikesUserId",
                table: "PhotoUser",
                newName: "PhotoFavoritesUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoUser_UserLikesPhotoId",
                table: "PhotoUser",
                newName: "IX_PhotoUser_UserFavoritesPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser_Photos_UserFavoritesPhotoId",
                table: "PhotoUser",
                column: "UserFavoritesPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser_Users_PhotoFavoritesUserId",
                table: "PhotoUser",
                column: "PhotoFavoritesUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser1_Photos_UserLikesPhotoId",
                table: "PhotoUser1",
                column: "UserLikesPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser1_Users_PhotoLikesUserId",
                table: "PhotoUser1",
                column: "PhotoLikesUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Photos_UserFavoritesPhotoId",
                table: "PhotoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Users_PhotoFavoritesUserId",
                table: "PhotoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser1_Photos_UserLikesPhotoId",
                table: "PhotoUser1");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser1_Users_PhotoLikesUserId",
                table: "PhotoUser1");

            migrationBuilder.RenameColumn(
                name: "UserLikesPhotoId",
                table: "PhotoUser1",
                newName: "UsersFavoritedUserId");

            migrationBuilder.RenameColumn(
                name: "PhotoLikesUserId",
                table: "PhotoUser1",
                newName: "FavPhotosPhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoUser1_UserLikesPhotoId",
                table: "PhotoUser1",
                newName: "IX_PhotoUser1_UsersFavoritedUserId");

            migrationBuilder.RenameColumn(
                name: "UserFavoritesPhotoId",
                table: "PhotoUser",
                newName: "UserLikesPhotoId");

            migrationBuilder.RenameColumn(
                name: "PhotoFavoritesUserId",
                table: "PhotoUser",
                newName: "PhotoLikesUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoUser_UserFavoritesPhotoId",
                table: "PhotoUser",
                newName: "IX_PhotoUser_UserLikesPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser_Photos_UserLikesPhotoId",
                table: "PhotoUser",
                column: "UserLikesPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser_Users_PhotoLikesUserId",
                table: "PhotoUser",
                column: "PhotoLikesUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser1_Photos_FavPhotosPhotoId",
                table: "PhotoUser1",
                column: "FavPhotosPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser1_Users_UsersFavoritedUserId",
                table: "PhotoUser1",
                column: "UsersFavoritedUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
