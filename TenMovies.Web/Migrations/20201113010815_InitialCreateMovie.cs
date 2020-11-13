using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TenMovies.Web.Migrations
{
    public partial class InitialCreateMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerUsername = table.Column<string>(maxLength: 30, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    UserId = table.Column<Guid>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    PrimaryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adult = table.Column<bool>(nullable: false),
                    BackdropPath = table.Column<string>(nullable: true),
                    Budget = table.Column<int>(nullable: false),
                    Homepage = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    ImdbId = table.Column<string>(nullable: true),
                    OriginalLanguage = table.Column<string>(nullable: true),
                    OriginalTitle = table.Column<string>(nullable: true),
                    Overview = table.Column<string>(nullable: true),
                    Popularity = table.Column<double>(nullable: false),
                    PosterPath = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    Revenue = table.Column<int>(nullable: false),
                    Runtime = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Tagline = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Video = table.Column<bool>(nullable: false),
                    VoteAverage = table.Column<double>(nullable: false),
                    VoteCount = table.Column<int>(nullable: false),
                    MovieListId = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.PrimaryId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieLists");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
