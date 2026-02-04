using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkshopArtistLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialMusicStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_ArtistID",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Genres_GenreID",
                table: "Albums");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "Genres",
                newName: "GenreId");

            migrationBuilder.RenameColumn(
                name: "ArtistID",
                table: "Artists",
                newName: "ArtistId");

            migrationBuilder.RenameColumn(
                name: "AlbumID",
                table: "Albums",
                newName: "AlbumId");

            migrationBuilder.RenameColumn(
                name: "GenreID",
                table: "Albums",
                newName: "FkGenreId");

            migrationBuilder.RenameColumn(
                name: "ArtistID",
                table: "Albums",
                newName: "FkArtistId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_GenreID",
                table: "Albums",
                newName: "IX_Albums_FkGenreId");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_ArtistID",
                table: "Albums",
                newName: "IX_Albums_FkArtistId");

            migrationBuilder.AlterColumn<string>(
                name: "GenreName",
                table: "Genres",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ArtistName",
                table: "Artists",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Albums",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "ArtistId", "ArtistName" },
                values: new object[,]
                {
                    { 1, "The Beatles" },
                    { 2, "Beyoncé" },
                    { 3, "Miles Davis" },
                    { 4, "Eminem" },
                    { 5, "Mozart" },
                    { 6, "Metallica" },
                    { 7, "Johnny Cash" },
                    { 8, "Avicii" },
                    { 9, "Bob Marley" },
                    { 10, "BB King" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Rock" },
                    { 2, "Pop" },
                    { 3, "Jazz" },
                    { 4, "Hip Hop" },
                    { 5, "Classical" },
                    { 6, "Metal" },
                    { 7, "Country" },
                    { 8, "Electronic" },
                    { 9, "Reggae" },
                    { 10, "Blues" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "AlbumId", "FkArtistId", "FkGenreId", "Title" },
                values: new object[,]
                {
                    { 1, 1, 1, "Abbey Road" },
                    { 2, 2, 2, "Lemonade" },
                    { 3, 3, 3, "Kind of Blue" },
                    { 4, 4, 4, "The Marshall Mathers LP" },
                    { 5, 5, 5, "Requiem" },
                    { 6, 6, 6, "Master of Puppets" },
                    { 7, 7, 7, "Ring of Fire" },
                    { 8, 8, 8, "True" },
                    { 9, 9, 9, "Exodus" },
                    { 10, 10, 10, "Live at the Regal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreName",
                table: "Genres",
                column: "GenreName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ArtistName",
                table: "Artists",
                column: "ArtistName",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_FkArtistId",
                table: "Albums",
                column: "FkArtistId",
                principalTable: "Artists",
                principalColumn: "ArtistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Genres_FkGenreId",
                table: "Albums",
                column: "FkGenreId",
                principalTable: "Genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Artists_FkArtistId",
                table: "Albums");

            migrationBuilder.DropForeignKey(
                name: "FK_Albums_Genres_FkGenreId",
                table: "Albums");

            migrationBuilder.DropIndex(
                name: "IX_Genres_GenreName",
                table: "Genres");

            migrationBuilder.DropIndex(
                name: "IX_Artists_ArtistName",
                table: "Artists");

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "AlbumId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "ArtistId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 10);

            migrationBuilder.RenameColumn(
                name: "GenreId",
                table: "Genres",
                newName: "GenreID");

            migrationBuilder.RenameColumn(
                name: "ArtistId",
                table: "Artists",
                newName: "ArtistID");

            migrationBuilder.RenameColumn(
                name: "AlbumId",
                table: "Albums",
                newName: "AlbumID");

            migrationBuilder.RenameColumn(
                name: "FkGenreId",
                table: "Albums",
                newName: "GenreID");

            migrationBuilder.RenameColumn(
                name: "FkArtistId",
                table: "Albums",
                newName: "ArtistID");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_FkGenreId",
                table: "Albums",
                newName: "IX_Albums_GenreID");

            migrationBuilder.RenameIndex(
                name: "IX_Albums_FkArtistId",
                table: "Albums",
                newName: "IX_Albums_ArtistID");

            migrationBuilder.AlterColumn<string>(
                name: "GenreName",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "ArtistName",
                table: "Artists",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Artists_ArtistID",
                table: "Albums",
                column: "ArtistID",
                principalTable: "Artists",
                principalColumn: "ArtistID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Albums_Genres_GenreID",
                table: "Albums",
                column: "GenreID",
                principalTable: "Genres",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
