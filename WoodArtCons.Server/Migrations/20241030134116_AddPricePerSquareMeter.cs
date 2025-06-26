using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodArtCons.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddPricePerSquareMeter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PricePerSquareMeter",
                table: "Products",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerSquareMeter",
                table: "Products");
        }
    }
}
