using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodArtCons.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    NameRo = table.Column<string>(type: "TEXT", nullable: false),
                    NameRu = table.Column<string>(type: "TEXT", nullable: false),
                    NameEn = table.Column<string>(type: "TEXT", nullable: false),
                    ImageSrc = table.Column<string>(type: "TEXT", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    IsForGalery = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<string>(type: "TEXT", nullable: false),
                    NameRo = table.Column<string>(type: "TEXT", nullable: false),
                    NameRu = table.Column<string>(type: "TEXT", nullable: false),
                    NameEn = table.Column<string>(type: "TEXT", nullable: false),
                    ImageSrc = table.Column<string>(type: "TEXT", nullable: false),
                    Lenght = table.Column<float>(type: "REAL", nullable: false),
                    Height = table.Column<float>(type: "REAL", nullable: false),
                    Width = table.Column<float>(type: "REAL", nullable: false),
                    Link = table.Column<string>(type: "TEXT", nullable: false),
                    DescriptionRo = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionRu = table.Column<string>(type: "TEXT", nullable: true),
                    DescriptionEn = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialRo = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialRu = table.Column<string>(type: "TEXT", nullable: true),
                    MaterialEn = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "BLOB", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "BLOB", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
