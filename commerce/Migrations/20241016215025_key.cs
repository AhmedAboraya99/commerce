using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace commerce.Migrations
{
    /// <inheritdoc />
    public partial class key : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UsersId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UsersId",
                table: "Products",
                newName: "userId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UsersId",
                table: "Products",
                newName: "IX_Products_userId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_userId",
                table: "Products",
                column: "userId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_userId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "userId",
                table: "Products",
                newName: "UsersId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_userId",
                table: "Products",
                newName: "IX_Products_UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UsersId",
                table: "Products",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
