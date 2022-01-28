using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryData.Migrations
{
    public partial class Addinitalentitymodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HomeMedicineBranchId",
                table: "Patrons",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LibraryCardId",
                table: "Patrons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MedicineBranchs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OpenDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineBranchs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BranchHours",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BranchId = table.Column<int>(type: "int", nullable: true),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    OpenTime = table.Column<int>(type: "int", nullable: false),
                    CloseTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchHours", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchHours_MedicineBranchs_BranchId",
                        column: x => x.BranchId,
                        principalTable: "MedicineBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MedicineAssets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfCopies = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: true),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NRMD = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameMedicine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeweyIndex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineAssets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineAssets_MedicineBranchs_LocationId",
                        column: x => x.LocationId,
                        principalTable: "MedicineBranchs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicineAssets_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineAssetId = table.Column<int>(type: "int", nullable: true),
                    MedicineCardId = table.Column<int>(type: "int", nullable: true),
                    CheckedOut = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckedIn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_MedicineAssets_MedicineAssetId",
                        column: x => x.MedicineAssetId,
                        principalTable: "MedicineAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CheckoutHistories_MedicineCards_MedicineCardId",
                        column: x => x.MedicineCardId,
                        principalTable: "MedicineCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Checkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineAssetId = table.Column<int>(type: "int", nullable: true),
                    MedicineCardId = table.Column<int>(type: "int", nullable: true),
                    Since = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Until = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Checkouts_MedicineAssets_MedicineAssetId",
                        column: x => x.MedicineAssetId,
                        principalTable: "MedicineAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checkouts_MedicineCards_MedicineCardId",
                        column: x => x.MedicineCardId,
                        principalTable: "MedicineCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Holds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicineAssetId = table.Column<int>(type: "int", nullable: true),
                    MedicineCardId = table.Column<int>(type: "int", nullable: true),
                    HoldPlaced = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Holds_MedicineAssets_MedicineAssetId",
                        column: x => x.MedicineAssetId,
                        principalTable: "MedicineAssets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Holds_MedicineCards_MedicineCardId",
                        column: x => x.MedicineCardId,
                        principalTable: "MedicineCards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_HomeMedicineBranchId",
                table: "Patrons",
                column: "HomeMedicineBranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrons_LibraryCardId",
                table: "Patrons",
                column: "LibraryCardId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchHours_BranchId",
                table: "BranchHours",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_MedicineAssetId",
                table: "CheckoutHistories",
                column: "MedicineAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutHistories_MedicineCardId",
                table: "CheckoutHistories",
                column: "MedicineCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_MedicineAssetId",
                table: "Checkouts",
                column: "MedicineAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Checkouts_MedicineCardId",
                table: "Checkouts",
                column: "MedicineCardId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_MedicineAssetId",
                table: "Holds",
                column: "MedicineAssetId");

            migrationBuilder.CreateIndex(
                name: "IX_Holds_MedicineCardId",
                table: "Holds",
                column: "MedicineCardId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineAssets_LocationId",
                table: "MedicineAssets",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicineAssets_StatusId",
                table: "MedicineAssets",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_MedicineBranchs_HomeMedicineBranchId",
                table: "Patrons",
                column: "HomeMedicineBranchId",
                principalTable: "MedicineBranchs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patrons_MedicineCards_LibraryCardId",
                table: "Patrons",
                column: "LibraryCardId",
                principalTable: "MedicineCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_MedicineBranchs_HomeMedicineBranchId",
                table: "Patrons");

            migrationBuilder.DropForeignKey(
                name: "FK_Patrons_MedicineCards_LibraryCardId",
                table: "Patrons");

            migrationBuilder.DropTable(
                name: "BranchHours");

            migrationBuilder.DropTable(
                name: "CheckoutHistories");

            migrationBuilder.DropTable(
                name: "Checkouts");

            migrationBuilder.DropTable(
                name: "Holds");

            migrationBuilder.DropTable(
                name: "MedicineAssets");

            migrationBuilder.DropTable(
                name: "MedicineCards");

            migrationBuilder.DropTable(
                name: "MedicineBranchs");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_HomeMedicineBranchId",
                table: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_Patrons_LibraryCardId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "HomeMedicineBranchId",
                table: "Patrons");

            migrationBuilder.DropColumn(
                name: "LibraryCardId",
                table: "Patrons");
        }
    }
}
