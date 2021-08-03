using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Photos_FavPhotosPhotoId",
                table: "PhotoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Users_UsersFavoritedUserId",
                table: "PhotoUser");

            migrationBuilder.RenameColumn(
                name: "UsersFavoritedUserId",
                table: "PhotoUser",
                newName: "LikesUserId");

            migrationBuilder.RenameColumn(
                name: "FavPhotosPhotoId",
                table: "PhotoUser",
                newName: "LikesPhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoUser_UsersFavoritedUserId",
                table: "PhotoUser",
                newName: "IX_PhotoUser_LikesUserId");

            migrationBuilder.CreateTable(
                name: "PhotoUser1",
                columns: table => new
                {
                    FavPhotosPhotoId = table.Column<int>(type: "int", nullable: false),
                    UsersFavoritedUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoUser1", x => new { x.FavPhotosPhotoId, x.UsersFavoritedUserId });
                    table.ForeignKey(
                        name: "FK_PhotoUser1_Photos_FavPhotosPhotoId",
                        column: x => x.FavPhotosPhotoId,
                        principalTable: "Photos",
                        principalColumn: "PhotoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhotoUser1_Users_UsersFavoritedUserId",
                        column: x => x.UsersFavoritedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhotoUser1_UsersFavoritedUserId",
                table: "PhotoUser1",
                column: "UsersFavoritedUserId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Photos_LikesPhotoId",
                table: "PhotoUser");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotoUser_Users_LikesUserId",
                table: "PhotoUser");

            migrationBuilder.DropTable(
                name: "PhotoUser1");

            migrationBuilder.RenameColumn(
                name: "LikesUserId",
                table: "PhotoUser",
                newName: "UsersFavoritedUserId");

            migrationBuilder.RenameColumn(
                name: "LikesPhotoId",
                table: "PhotoUser",
                newName: "FavPhotosPhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_PhotoUser_LikesUserId",
                table: "PhotoUser",
                newName: "IX_PhotoUser_UsersFavoritedUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser_Photos_FavPhotosPhotoId",
                table: "PhotoUser",
                column: "FavPhotosPhotoId",
                principalTable: "Photos",
                principalColumn: "PhotoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PhotoUser_Users_UsersFavoritedUserId",
                table: "PhotoUser",
                column: "UsersFavoritedUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
