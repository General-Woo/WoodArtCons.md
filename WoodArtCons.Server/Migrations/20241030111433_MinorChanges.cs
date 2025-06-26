using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodArtCons.Server.Migrations
{
    /// <inheritdoc />
    public partial class MinorChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "REAL");

            migrationBuilder.AlterColumn<string>(
                name: "Lenght",
                table: "Products",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "REAL",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "Products",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<float>(
                name: "Lenght",
                table: "Products",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
