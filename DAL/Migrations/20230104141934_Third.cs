using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class Third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MealName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserTypes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Foods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Calorie = table.Column<double>(type: "float(2)", precision: 2, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Foods_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "MealFoods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Portion = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    MealId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateOn = table.Column<DateTime>(type: "datetime", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealFoods", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MealFoods_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealFoods_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealFoods_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "ID", "CategoryName", "CreateOn", "IsActive", "UpdateOn" },
                values: new object[,]
                {
                    { 1, "Süt Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(192), true, null },
                    { 2, "Et Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(195), true, null },
                    { 3, "KuruBaklagil Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(196), true, null },
                    { 4, "Ekmek Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(197), true, null },
                    { 5, "Sebze Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(198), true, null },
                    { 6, "Meyve Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(199), true, null },
                    { 7, "Yağ Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(200), true, null },
                    { 8, "Tatlı Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(200), true, null },
                    { 9, "Kuruyemiş Grubu", new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(201), true, null }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "ID", "CreateOn", "IsActive", "MealName", "UpdateOn" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 4, 17, 19, 33, 920, DateTimeKind.Local).AddTicks(8147), true, "Kahvaltı", null },
                    { 2, new DateTime(2023, 1, 4, 17, 19, 33, 920, DateTimeKind.Local).AddTicks(8151), true, "Öğle Yemeği", null },
                    { 3, new DateTime(2023, 1, 4, 17, 19, 33, 920, DateTimeKind.Local).AddTicks(8152), true, "Akşam Yemeği", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreateOn", "Email", "IsActive", "Password", "UpdateOn", "UserName", "UserTypes" },
                values: new object[] { 1, new DateTime(2023, 1, 4, 17, 19, 33, 920, DateTimeKind.Local).AddTicks(6138), "admin@gmail.com", true, "123456", null, "Admin", "Admin" });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "ID", "Calorie", "CategoryId", "CreateOn", "Description", "FoodName", "IsActive", "UpdateOn" },
                values: new object[,]
                {
                    { 1, 11400.0, 1, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2509), "1 su bardağı, 200ml", "Süt", true, null },
                    { 2, 69000.0, 2, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2513), "1 köfte, 30gr", "Kıyma", true, null },
                    { 3, 80000.0, 3, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2514), "4 yemek kaşığı, 25gr", "Mercimek", true, null },
                    { 4, 68000.0, 4, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2515), "3 yemek kaşığı, 50gr", "Makarna", true, null },
                    { 5, 25000.0, 5, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2516), "4 yemek kaşığı, 200gr", "Brokoli(pişmiş)", true, null },
                    { 6, 60000.0, 6, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2517), "1 küçük boy, 120gr", "Elma", true, null },
                    { 7, 45000.0, 7, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2518), "1 tatlı kaşığı, 5gr", "Tereyağ", true, null },
                    { 8, 68000.0, 8, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2519), "1 yemek kaşığı, 30gr", "Bal", true, null },
                    { 9, 45000.0, 9, new DateTime(2023, 1, 4, 17, 19, 33, 921, DateTimeKind.Local).AddTicks(2519), "2 adet, 8gr", "Ceviz içi", true, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryName",
                table: "Categories",
                column: "CategoryName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_CategoryId",
                table: "Foods",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Foods_FoodName",
                table: "Foods",
                column: "FoodName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_FoodId",
                table: "MealFoods",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_MealId",
                table: "MealFoods",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealFoods_UserId",
                table: "MealFoods",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealName",
                table: "Meals",
                column: "MealName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealFoods");

            migrationBuilder.DropTable(
                name: "Foods");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
