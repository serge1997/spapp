using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spapp.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressColumnsInAgentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Complement",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HouseNumber",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Indication",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complement",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "HouseNumber",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "Indication",
                table: "Agents");
        }
    }
}
