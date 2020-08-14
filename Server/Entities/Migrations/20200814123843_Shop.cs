using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entities.Migrations
{
    public partial class Shop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameServers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameServers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatorId = table.Column<Guid>(nullable: false),
                    RuTitle = table.Column<string>(nullable: true),
                    EnTitle = table.Column<string>(nullable: true),
                    Icon = table.Column<string>(nullable: true),
                    Count = table.Column<int>(nullable: false),
                    Coins = table.Column<int>(nullable: false),
                    ECoins = table.Column<int>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    DiscountEndDate = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(nullable: false),
                    RuTitle = table.Column<string>(nullable: true),
                    EnTitle = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    ServerId = table.Column<int>(nullable: false),
                    GameServerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_GameServers_GameServerId",
                        column: x => x.GameServerId,
                        principalTable: "GameServers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false),
                    ItemId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCategories", x => new { x.ItemId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ItemCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCategories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "EnTitle", "GameServerId", "RuTitle", "ServerId", "UpdatedAt" },
                values: new object[,]
                {
                    { -1, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -1", null, "Категория -1", -4, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -2, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -2", null, "Категория -2", -1, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -3, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -3", null, "Категория -3", -1, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -4, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -4", null, "Категория -4", -3, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -5, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -5", null, "Категория -5", -1, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -6, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -6", null, "Категория -6", -2, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -7, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -7", null, "Категория -7", -1, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -8, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -8", null, "Категория -8", -3, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -9, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -9", null, "Категория -9", -1, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -10, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -10", null, "Категория -10", -4, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) }
                });

            migrationBuilder.InsertData(
                table: "GameServers",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { -4, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Arcmagic", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -3, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Ozone", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -2, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Unfinity", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { -1, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Infinity", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Coins", "Count", "CreatedAt", "CreatorId", "Discount", "DiscountEndDate", "ECoins", "EnTitle", "Icon", "RuTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("c5c20d89-bf65-478a-8220-dd213557afc7"), 51, 5, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -1", "Icon", "Предмет -1", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("46e28c72-845b-40df-b394-cddf6f7b72e1"), 54, 9, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -2", "Icon", "Предмет -2", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("1f7d5d70-be1e-4142-990e-29469fa0dbfd"), 31, 4, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -3", "Icon", "Предмет -3", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("31a9f930-b04a-4298-b5a4-e0b685eecdc7"), 95, 8, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -4", "Icon", "Предмет -4", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("fb60ca79-055c-423e-a539-97faa22c06f2"), 77, 5, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -5", "Icon", "Предмет -5", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("05b52641-7e0b-4b37-9001-ef88456aed1d"), 19, 10, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -6", "Icon", "Предмет -6", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("a1d831b0-9b0e-49d8-96a9-eb29f8ba9ae5"), 38, 5, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -7", "Icon", "Предмет -7", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("266e0fee-58be-4ec0-84ac-dfcbbd8ff35d"), 16, 10, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -8", "Icon", "Предмет -8", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("e3a978b2-b6f1-42b3-bd34-e9b7c7c484f2"), 75, 10, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -9", "Icon", "Предмет -9", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) },
                    { new Guid("2ded42df-bdf3-4d3d-aadc-a49c3354ed5a"), 81, 10, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477), 0, "Item -10", "Icon", "Предмет -10", new DateTime(2020, 8, 14, 12, 38, 42, 675, DateTimeKind.Utc).AddTicks(5477) }
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "ItemId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("c5c20d89-bf65-478a-8220-dd213557afc7"), -1 },
                    { new Guid("46e28c72-845b-40df-b394-cddf6f7b72e1"), -2 },
                    { new Guid("1f7d5d70-be1e-4142-990e-29469fa0dbfd"), -3 },
                    { new Guid("31a9f930-b04a-4298-b5a4-e0b685eecdc7"), -4 },
                    { new Guid("fb60ca79-055c-423e-a539-97faa22c06f2"), -5 },
                    { new Guid("05b52641-7e0b-4b37-9001-ef88456aed1d"), -6 },
                    { new Guid("a1d831b0-9b0e-49d8-96a9-eb29f8ba9ae5"), -7 },
                    { new Guid("266e0fee-58be-4ec0-84ac-dfcbbd8ff35d"), -8 },
                    { new Guid("e3a978b2-b6f1-42b3-bd34-e9b7c7c484f2"), -9 },
                    { new Guid("2ded42df-bdf3-4d3d-aadc-a49c3354ed5a"), -10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GameServerId",
                table: "Categories",
                column: "GameServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCategories_CategoryId",
                table: "ItemCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "GameServers");
        }
    }
}
