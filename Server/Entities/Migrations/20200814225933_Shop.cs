using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Entities.Migrations
{
    public partial class Shop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

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
                    GameServerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_GameServers_GameServerId",
                        column: x => x.GameServerId,
                        principalTable: "GameServers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                table: "GameServers",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { -1, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Infinity", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -2, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Unfinity", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -3, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Ozone", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -4, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Arcmagic", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Coins", "Count", "CreatedAt", "CreatorId", "Discount", "DiscountEndDate", "ECoins", "EnTitle", "Icon", "RuTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("51bfc407-478a-404d-a5a8-c6b6d5bc8d60"), 26, 4, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -1", "Icon", "Предмет -1", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("67c5c6a7-d547-40a8-9699-850d41ff168a"), 84, 8, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -2", "Icon", "Предмет -2", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("8c73e29e-81b5-46fe-b1da-334133355320"), 26, 9, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -3", "Icon", "Предмет -3", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("b7531636-8db0-40e1-91b0-08df652fcb5f"), 83, 1, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -4", "Icon", "Предмет -4", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("95d03040-46ca-42e6-bc32-6aae87c3e1ac"), 30, 2, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -5", "Icon", "Предмет -5", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("cdedb443-907b-4a75-8941-3ba021aea0bc"), 95, 8, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -6", "Icon", "Предмет -6", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("8da7ebea-8c10-4088-b56e-f26eb15f81a4"), 97, 6, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -7", "Icon", "Предмет -7", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("830a0946-4f90-462d-b6ce-63b7707ce8b5"), 48, 4, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -8", "Icon", "Предмет -8", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("7c003f7e-d2c2-4ab0-8a6b-2e4f25a62c6a"), 51, 8, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -9", "Icon", "Предмет -9", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { new Guid("85843659-e96f-4549-9c48-266c9333a088"), 14, 2, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), 0, "Item -10", "Icon", "Предмет -10", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "EnTitle", "GameServerId", "RuTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { -5, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -5", -1, "Категория -5", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -1, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -1", -2, "Категория -1", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -6, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -6", -3, "Категория -6", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -10, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -10", -3, "Категория -10", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -2, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -2", -4, "Категория -2", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -3, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -3", -4, "Категория -3", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -4, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -4", -4, "Категория -4", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -7, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -7", -4, "Категория -7", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -8, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -8", -4, "Категория -8", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) },
                    { -9, new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category -9", -4, "Категория -9", new DateTime(2020, 8, 14, 22, 59, 31, 696, DateTimeKind.Utc).AddTicks(8045) }
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "ItemId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("95d03040-46ca-42e6-bc32-6aae87c3e1ac"), -5 },
                    { new Guid("51bfc407-478a-404d-a5a8-c6b6d5bc8d60"), -1 },
                    { new Guid("cdedb443-907b-4a75-8941-3ba021aea0bc"), -6 },
                    { new Guid("85843659-e96f-4549-9c48-266c9333a088"), -10 },
                    { new Guid("67c5c6a7-d547-40a8-9699-850d41ff168a"), -2 },
                    { new Guid("8c73e29e-81b5-46fe-b1da-334133355320"), -3 },
                    { new Guid("b7531636-8db0-40e1-91b0-08df652fcb5f"), -4 },
                    { new Guid("8da7ebea-8c10-4088-b56e-f26eb15f81a4"), -7 },
                    { new Guid("830a0946-4f90-462d-b6ce-63b7707ce8b5"), -8 },
                    { new Guid("7c003f7e-d2c2-4ab0-8a6b-2e4f25a62c6a"), -9 }
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

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
