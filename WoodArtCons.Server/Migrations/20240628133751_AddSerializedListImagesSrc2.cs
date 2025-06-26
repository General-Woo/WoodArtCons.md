using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WoodArtCons.Server.Migrations
{
    /// <inheritdoc />
    public partial class AddSerializedListImagesSrc2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerializedListImagesSrc",
                table: "Products",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SerializedListImagesSrc",
                table: "Products");
        }
    }
}
