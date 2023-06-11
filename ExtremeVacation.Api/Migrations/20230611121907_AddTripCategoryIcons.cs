using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExtremeVacation.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddTripCategoryIcons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IconCSS",
                table: "TripCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "TripCategories",
                keyColumn: "Id",
                keyValue: 1,
                column: "IconCSS",
                value: "fa-solid fa-city");

            migrationBuilder.UpdateData(
                table: "TripCategories",
                keyColumn: "Id",
                keyValue: 2,
                column: "IconCSS",
                value: "fa-solid fa-mountain-sun");

            migrationBuilder.UpdateData(
                table: "TripCategories",
                keyColumn: "Id",
                keyValue: 3,
                column: "IconCSS",
                value: "fa-solid fa-person-swimming");

            migrationBuilder.UpdateData(
                table: "TripCategories",
                keyColumn: "Id",
                keyValue: 4,
                column: "IconCSS",
                value: "fa-solid fa-ghost");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IconCSS",
                table: "TripCategories");
        }
    }
}
