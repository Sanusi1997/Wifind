using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WiFind.Migrations
{
    /// <inheritdoc />
    public partial class added_payment_and_wifi_connection_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentAmount = table.Column<double>(type: "float", nullable: false),
                    IsVerified = table.Column<bool>(type: "bit", nullable: false),
                    WiFindUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WifiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "WifiConnections",
                columns: table => new
                {
                    WifiConnectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConnectionStartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ConnectionEndTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsExpired = table.Column<bool>(type: "bit", nullable: false),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WifiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WiFindUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WifiConnections", x => x.WifiConnectionId);
                });

            migrationBuilder.CreateTable(
                name: "WifindUsers",
                columns: table => new
                {
                    WiFindUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateTimeModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WifiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WifindUsers", x => x.WiFindUserId);
                });

            migrationBuilder.CreateTable(
                name: "Wifis",
                columns: table => new
                {
                    WifiId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WifiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Speed = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfUsers = table.Column<int>(type: "int", nullable: false),
                    AmountEarned = table.Column<double>(type: "float", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WiFindUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifis", x => x.WifiId);
                    table.ForeignKey(
                        name: "FK_Wifis_WifindUsers_WiFindUserId",
                        column: x => x.WiFindUserId,
                        principalTable: "WifindUsers",
                        principalColumn: "WiFindUserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Payments_WifiId",
                table: "Payments",
                column: "WifiId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_WiFindUserId",
                table: "Payments",
                column: "WiFindUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WifiConnections_WifiId",
                table: "WifiConnections",
                column: "WifiId");

            migrationBuilder.CreateIndex(
                name: "IX_WifiConnections_WiFindUserId",
                table: "WifiConnections",
                column: "WiFindUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WifindUsers_WifiId",
                table: "WifindUsers",
                column: "WifiId");

            migrationBuilder.CreateIndex(
                name: "IX_Wifis_WiFindUserId",
                table: "Wifis",
                column: "WiFindUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_WifindUsers_WiFindUserId",
                table: "Payments",
                column: "WiFindUserId",
                principalTable: "WifindUsers",
                principalColumn: "WiFindUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Wifis_WifiId",
                table: "Payments",
                column: "WifiId",
                principalTable: "Wifis",
                principalColumn: "WifiId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WifiConnections_WifindUsers_WiFindUserId",
                table: "WifiConnections",
                column: "WiFindUserId",
                principalTable: "WifindUsers",
                principalColumn: "WiFindUserId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WifiConnections_Wifis_WifiId",
                table: "WifiConnections",
                column: "WifiId",
                principalTable: "Wifis",
                principalColumn: "WifiId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WifindUsers_Wifis_WifiId",
                table: "WifindUsers",
                column: "WifiId",
                principalTable: "Wifis",
                principalColumn: "WifiId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wifis_WifindUsers_WiFindUserId",
                table: "Wifis");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "WifiConnections");

            migrationBuilder.DropTable(
                name: "WifindUsers");

            migrationBuilder.DropTable(
                name: "Wifis");
        }
    }
}
