using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace spapp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddressIdFKReferencialACtion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
               name: "FK_Agents_Addresses_AddressId",
               table: "Agents");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Addresses_AddressId",
                table: "Agents",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agents_Addresses_AddressId",
                table: "Agents");

            migrationBuilder.AddForeignKey(
                name: "FK_Agents_Addresses_AddressId",
                table: "Agents",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
