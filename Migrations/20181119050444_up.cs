using Microsoft.EntityFrameworkCore.Migrations;

namespace moneygoes.Migrations
{
    public partial class up : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Goods_PurchaseObjectId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseObjectId",
                table: "Purchases",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Goods_PurchaseObjectId",
                table: "Purchases",
                column: "PurchaseObjectId",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Purchases_Goods_PurchaseObjectId",
                table: "Purchases");

            migrationBuilder.AlterColumn<int>(
                name: "PurchaseObjectId",
                table: "Purchases",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Purchases_Goods_PurchaseObjectId",
                table: "Purchases",
                column: "PurchaseObjectId",
                principalTable: "Goods",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
