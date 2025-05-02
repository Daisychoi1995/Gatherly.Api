using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gatherly.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studies_Users_UserNameId",
                table: "Studies");

            migrationBuilder.DropIndex(
                name: "IX_Studies_UserNameId",
                table: "Studies");

            migrationBuilder.DropColumn(
                name: "UserNameId",
                table: "Studies");

            migrationBuilder.RenameColumn(
                name: "CreatorId",
                table: "Studies",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Studies_UserId",
                table: "Studies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studies_Users_UserId",
                table: "Studies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Studies_Users_UserId",
                table: "Studies");

            migrationBuilder.DropIndex(
                name: "IX_Studies_UserId",
                table: "Studies");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Studies",
                newName: "CreatorId");

            migrationBuilder.AddColumn<int>(
                name: "UserNameId",
                table: "Studies",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Studies",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserNameId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Studies_UserNameId",
                table: "Studies",
                column: "UserNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Studies_Users_UserNameId",
                table: "Studies",
                column: "UserNameId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
