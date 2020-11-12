using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TenMovies.Web.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovieLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adult = table.Column<bool>(nullable: false),
                    BackdropPath = table.Column<string>(nullable: true),
                    Budget = table.Column<int>(nullable: false),
                    Homepage = table.Column<string>(nullable: true),
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
                    MovieListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
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
