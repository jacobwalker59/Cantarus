using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDeals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Count = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ProductItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDeals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductDeals_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductItems",
                columns: new[] { "Id", "ProductName", "ProductPrice" },
                values: new object[] { 1, "Apples", 1f });

            migrationBuilder.InsertData(
                table: "ProductDeals",
                columns: new[] { "Id", "Count", "Price", "ProductItemId" },
                values: new object[] { 1, 3, 2f, 1 });

            migrationBuilder.InsertData(
                table: "ProductDeals",
                columns: new[] { "Id", "Count", "Price", "ProductItemId" },
                values: new object[] { 2, 7, 4.2f, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_ProductDeals_ProductItemId",
                table: "ProductDeals",
                column: "ProductItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDeals");

            migrationBuilder.DropTable(
                name: "ProductItems");
        }
    }
}
