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
                    { 1, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 1", null, "Категория 1", 1, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 2, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 2", null, "Категория 2", 4, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 3, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 3", null, "Категория 3", 2, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 4, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 4", null, "Категория 4", 3, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 5, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 5", null, "Категория 5", 1, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 6, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 6", null, "Категория 6", 4, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 7, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 7", null, "Категория 7", 2, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 8, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 8", null, "Категория 8", 2, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 9, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 9", null, "Категория 9", 3, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 10, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Category 10", null, "Категория 10", 3, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) }
                });

            migrationBuilder.InsertData(
                table: "GameServers",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 4, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Arcmagic", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 3, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Ozone", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 2, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Unfinity", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { 1, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "Infinity", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Coins", "Count", "CreatedAt", "CreatorId", "Discount", "DiscountEndDate", "ECoins", "EnTitle", "Icon", "RuTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("f47c540b-caf4-4a6e-91ac-b5db5716971e"), 80, 5, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 1", "Icon", "Предмет 1", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("2c32eb66-2a05-49f1-b894-bf48fc0bfee5"), 28, 3, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 2", "Icon", "Предмет 2", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("7e1294d3-b9bc-442d-8da7-7087fc801222"), 17, 9, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 3", "Icon", "Предмет 3", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("2af07970-00e2-4623-a370-e8e5d8ec5797"), 69, 5, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 4", "Icon", "Предмет 4", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("62b5b7db-d52e-48d1-aa9b-ec50ad46fe59"), 61, 1, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 5", "Icon", "Предмет 5", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("23971dcb-fd37-4df5-961b-329e6488ff5f"), 74, 3, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 6", "Icon", "Предмет 6", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("deae84c9-21a6-4331-9ac1-8afca4bfb6d6"), 82, 8, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 7", "Icon", "Предмет 7", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("204e41c7-040e-4904-8473-4c6a1b01e86c"), 37, 5, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 8", "Icon", "Предмет 8", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("854826f3-eb47-4fc1-a1dd-3810e3784e63"), 77, 10, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 9", "Icon", "Предмет 9", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) },
                    { new Guid("d4ed8bed-fa7c-444f-807e-b75b67b15f40"), 65, 1, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116), 0, "Item 10", "Icon", "Предмет 10", new DateTime(2020, 8, 13, 13, 51, 58, 815, DateTimeKind.Utc).AddTicks(8116) }
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "ItemId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("f47c540b-caf4-4a6e-91ac-b5db5716971e"), 1 },
                    { new Guid("2c32eb66-2a05-49f1-b894-bf48fc0bfee5"), 2 },
                    { new Guid("7e1294d3-b9bc-442d-8da7-7087fc801222"), 3 },
                    { new Guid("2af07970-00e2-4623-a370-e8e5d8ec5797"), 4 },
                    { new Guid("62b5b7db-d52e-48d1-aa9b-ec50ad46fe59"), 5 },
                    { new Guid("23971dcb-fd37-4df5-961b-329e6488ff5f"), 6 },
                    { new Guid("deae84c9-21a6-4331-9ac1-8afca4bfb6d6"), 7 },
                    { new Guid("204e41c7-040e-4904-8473-4c6a1b01e86c"), 8 },
                    { new Guid("854826f3-eb47-4fc1-a1dd-3810e3784e63"), 9 },
                    { new Guid("d4ed8bed-fa7c-444f-807e-b75b67b15f40"), 10 }
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
