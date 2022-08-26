using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManGAGA_DAL.Migrations
{
    public partial class modelchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapers_Mangas_MangaID",
                table: "Chapers");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Users_userId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Mangas_MangaGId",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Favourites_FavouritesId",
                table: "Mangas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites");

            migrationBuilder.RenameTable(
                name: "Favourites",
                newName: "Favorites");

            migrationBuilder.RenameColumn(
                name: "score",
                table: "Mangas",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "FavouritesId",
                table: "Mangas",
                newName: "FavouritesID");

            migrationBuilder.RenameColumn(
                name: "MangaGId",
                table: "Mangas",
                newName: "MangaGID");

            migrationBuilder.RenameIndex(
                name: "IX_Mangas_FavouritesId",
                table: "Mangas",
                newName: "IX_Mangas_FavouritesID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Genders",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "MangaGId",
                table: "Genders",
                newName: "MangaGID");

            migrationBuilder.RenameColumn(
                name: "gendersID",
                table: "Genders",
                newName: "GendersID");

            migrationBuilder.RenameIndex(
                name: "IX_Genders_MangaGId",
                table: "Genders",
                newName: "IX_Genders_MangaGID");

            migrationBuilder.RenameColumn(
                name: "MangaID",
                table: "Chapers",
                newName: "MangaGID");

            migrationBuilder.RenameIndex(
                name: "IX_Chapers_MangaID",
                table: "Chapers",
                newName: "IX_Chapers_MangaGID");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Favorites",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "FavouritesId",
                table: "Favorites",
                newName: "FavouritesID");

            migrationBuilder.RenameIndex(
                name: "IX_Favourites_userId",
                table: "Favorites",
                newName: "IX_Favorites_UserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites",
                column: "FavouritesID");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapers_Mangas_MangaGID",
                table: "Chapers",
                column: "MangaGID",
                principalTable: "Mangas",
                principalColumn: "MangaGID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Mangas_MangaGID",
                table: "Genders",
                column: "MangaGID",
                principalTable: "Mangas",
                principalColumn: "MangaGID");

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Favorites_FavouritesID",
                table: "Mangas",
                column: "FavouritesID",
                principalTable: "Favorites",
                principalColumn: "FavouritesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chapers_Mangas_MangaGID",
                table: "Chapers");

            migrationBuilder.DropForeignKey(
                name: "FK_Favorites_Users_UserID",
                table: "Favorites");

            migrationBuilder.DropForeignKey(
                name: "FK_Genders_Mangas_MangaGID",
                table: "Genders");

            migrationBuilder.DropForeignKey(
                name: "FK_Mangas_Favorites_FavouritesID",
                table: "Mangas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Favorites",
                table: "Favorites");

            migrationBuilder.RenameTable(
                name: "Favorites",
                newName: "Favourites");

            migrationBuilder.RenameColumn(
                name: "Score",
                table: "Mangas",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "FavouritesID",
                table: "Mangas",
                newName: "FavouritesId");

            migrationBuilder.RenameColumn(
                name: "MangaGID",
                table: "Mangas",
                newName: "MangaGId");

            migrationBuilder.RenameIndex(
                name: "IX_Mangas_FavouritesID",
                table: "Mangas",
                newName: "IX_Mangas_FavouritesId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genders",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "MangaGID",
                table: "Genders",
                newName: "MangaGId");

            migrationBuilder.RenameColumn(
                name: "GendersID",
                table: "Genders",
                newName: "gendersID");

            migrationBuilder.RenameIndex(
                name: "IX_Genders_MangaGID",
                table: "Genders",
                newName: "IX_Genders_MangaGId");

            migrationBuilder.RenameColumn(
                name: "MangaGID",
                table: "Chapers",
                newName: "MangaID");

            migrationBuilder.RenameIndex(
                name: "IX_Chapers_MangaGID",
                table: "Chapers",
                newName: "IX_Chapers_MangaID");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Favourites",
                newName: "userId");

            migrationBuilder.RenameColumn(
                name: "FavouritesID",
                table: "Favourites",
                newName: "FavouritesId");

            migrationBuilder.RenameIndex(
                name: "IX_Favorites_UserID",
                table: "Favourites",
                newName: "IX_Favourites_userId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Favourites",
                table: "Favourites",
                column: "FavouritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chapers_Mangas_MangaID",
                table: "Chapers",
                column: "MangaID",
                principalTable: "Mangas",
                principalColumn: "MangaGId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Users_userId",
                table: "Favourites",
                column: "userId",
                principalTable: "Users",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Genders_Mangas_MangaGId",
                table: "Genders",
                column: "MangaGId",
                principalTable: "Mangas",
                principalColumn: "MangaGId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mangas_Favourites_FavouritesId",
                table: "Mangas",
                column: "FavouritesId",
                principalTable: "Favourites",
                principalColumn: "FavouritesId");
        }
    }
}
