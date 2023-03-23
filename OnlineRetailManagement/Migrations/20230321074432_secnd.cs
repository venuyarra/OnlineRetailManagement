using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineRetailManagement.Migrations
{
    /// <inheritdoc />
    public partial class secnd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "carts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "carts");
        }
    }
}
