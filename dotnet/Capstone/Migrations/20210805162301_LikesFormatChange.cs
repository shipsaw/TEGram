using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class LikesFormatChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Photos_LikesPhotoId",
                table: "PhotoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Users_LikesUserId",
                table: "PhotoUser");

            migrationBuilder.RenameColumn(
                name: "LikesUserId",
                table: "PhotoUser",
                newName: "UserLikesPhotoId");

            migrationBuilder.RenameColumn(
                name: "LikesPhotoId",
                table: "PhotoUser",
                newName: "PhotoLikesUserId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoUser_LikesUserId",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Photos_UserLikesPhotoId",
                table: "PhotoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Users_PhotoLikesUserId",
                table: "PhotoUser");

            migrationBuilder.RenameColumn(
                name: "UserLikesPhotoId",
                table: "PhotoUser",
                newName: "LikesUserId");

            migrationBuilder.RenameColumn(
                name: "PhotoLikesUserId",
                table: "PhotoUser",
                newName: "LikesPhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoUser_UserLikesPhotoId",
                table: "PhotoUser",
                newName: "IX_PhotoUser_LikesUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser_Photos_LikesPhotoId",
                table: "PhotoUser",
                column: "LikesPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser_Users_LikesUserId",
                table: "PhotoUser",
                column: "LikesUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
