using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelService.Infrastructure.Migrations
{
    public partial class initials : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    UUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorizedPersonFirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AuthorizedPersonLastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ReportRequests",
                columns: table => new
                {
                    UUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRequests", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ContactModels",
                columns: table => new
                {
                    UUID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelUUID = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactModels", x => x.UUID);
                    table.ForeignKey(
                        name: "FK_ContactModels_Hotels_HotelUUID",
                        column: x => x.HotelUUID,
                        principalTable: "Hotels",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetails",
                columns: table => new
                {
                    ReportRequestId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportRequestUUID = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelCount = table.Column<int>(type: "int", nullable: false),
                    NumberCount = table.Column<int>(type: "int", nullable: false),
                    UUID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetails", x => x.ReportRequestId);
                    table.ForeignKey(
                        name: "FK_ReportDetails_ReportRequests_ReportRequestUUID",
                        column: x => x.ReportRequestUUID,
                        principalTable: "ReportRequests",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactModels_HotelUUID",
                table: "ContactModels",
                column: "HotelUUID");

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetails_ReportRequestUUID",
                table: "ReportDetails",
                column: "ReportRequestUUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactModels");

            migrationBuilder.DropTable(
                name: "ReportDetails");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "ReportRequests");
        }
    }
}
