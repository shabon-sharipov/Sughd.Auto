using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sughd.Auto.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCarNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarNumber",
                table: "Car",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarNumber",
                table: "Car");
        }
    }
}
