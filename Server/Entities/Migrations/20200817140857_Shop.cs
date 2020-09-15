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

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastActivity",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GameServers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatorId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false)
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
                    DiscountStartDate = table.Column<DateTimeOffset>(nullable: false),
                    DiscountEndDate = table.Column<DateTimeOffset>(nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false)
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
                    CreatedAt = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(nullable: false),
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
                    { -1, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "infinity", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -2, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "unfinity", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -3, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "ozone", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -4, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "arcmagic", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Coins", "Count", "CreatedAt", "CreatorId", "Discount", "DiscountEndDate", "DiscountStartDate", "ECoins", "EnTitle", "Icon", "RuTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("fcf610bd-e0f5-4d66-ae84-c451434b479a"), 42, 3, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -1", "icon", "предмет -1", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("a426acc9-a2f4-4531-98bb-68508c3d6220"), 52, 4, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -2", "icon", "предмет -2", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("b620d15d-bc45-4785-b075-18db300c8c35"), 45, 9, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -3", "icon", "предмет -3", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("5bef3437-99d5-4828-9004-8177c8d5b47e"), 77, 3, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -4", "icon", "предмет -4", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("ce3403ab-2f21-44ce-9fdc-392bd839e944"), 62, 4, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -5", "icon", "предмет -5", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("4b7b6ca8-d812-4328-a929-58f76b242333"), 71, 1, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -6", "icon", "предмет -6", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("37c0074d-ebf9-4f56-987a-76095237498d"), 44, 2, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -7", "icon", "предмет -7", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("e00234c5-a343-495a-b036-f1098bfeb971"), 82, 6, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -8", "icon", "предмет -8", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("c628d527-6a12-40db-a33d-04cf8ad431b6"), 59, 6, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -9", "icon", "предмет -9", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { new Guid("773dc83b-8600-4657-951c-bd25983a7d5d"), 39, 9, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), 0.0, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), 0, "item -10", "icon", "предмет -10", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatorId", "EnTitle", "GameServerId", "RuTitle", "UpdatedAt" },
                values: new object[,]
                {
                    { -2, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -2", -1, "категория -2", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -10, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -10", -1, "категория -10", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -1, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -1", -2, "категория -1", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -3, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -3", -2, "категория -3", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -4, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -4", -2, "категория -4", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -6, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -6", -2, "категория -6", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -7, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -7", -2, "категория -7", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -8, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -8", -2, "категория -8", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -5, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -5", -3, "категория -5", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) },
                    { -9, new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)), new Guid("95024899-0ae4-4916-bdf4-7cd55c11128b"), "category -9", -4, "категория -9", new DateTimeOffset(new DateTime(2020, 8, 17, 14, 8, 56, 609, DateTimeKind.Unspecified).AddTicks(6481), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "ItemCategories",
                columns: new[] { "ItemId", "CategoryId" },
                values: new object[,]
                {
                    { new Guid("a426acc9-a2f4-4531-98bb-68508c3d6220"), -2 },
                    { new Guid("773dc83b-8600-4657-951c-bd25983a7d5d"), -10 },
                    { new Guid("fcf610bd-e0f5-4d66-ae84-c451434b479a"), -1 },
                    { new Guid("b620d15d-bc45-4785-b075-18db300c8c35"), -3 },
                    { new Guid("5bef3437-99d5-4828-9004-8177c8d5b47e"), -4 },
                    { new Guid("4b7b6ca8-d812-4328-a929-58f76b242333"), -6 },
                    { new Guid("37c0074d-ebf9-4f56-987a-76095237498d"), -7 },
                    { new Guid("e00234c5-a343-495a-b036-f1098bfeb971"), -8 },
                    { new Guid("ce3403ab-2f21-44ce-9fdc-392bd839e944"), -5 },
                    { new Guid("c628d527-6a12-40db-a33d-04cf8ad431b6"), -9 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_GameServerId",
                table: "Categories",
                column: "GameServerId");

            migrationBuilder.CreateIndex(
                name: "IX_GameServers_Title",
                table: "GameServers",
                column: "Title",
                unique: true);

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

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegistrationDate",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastActivity",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "AspNetUsers",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTimeOffset),
                oldNullable: true);

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
