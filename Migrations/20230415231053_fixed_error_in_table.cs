using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WiFind.Migrations
{
    /// <inheritdoc />
    public partial class fixed_error_in_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WifindUsers_Wifis_WifiId",
                table: "WifindUsers");

            migrationBuilder.DropIndex(
                name: "IX_WifindUsers_WifiId",
                table: "WifindUsers");

            migrationBuilder.DropColumn(
                name: "WifiId",
                table: "WifindUsers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WifiId",
                table: "WifindUsers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_WifindUsers_WifiId",
                table: "WifindUsers",
                column: "WifiId");

            migrationBuilder.AddForeignKey(
                name: "FK_WifindUsers_Wifis_WifiId",
                table: "WifindUsers",
                column: "WifiId",
                principalTable: "Wifis",
                principalColumn: "WifiId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
