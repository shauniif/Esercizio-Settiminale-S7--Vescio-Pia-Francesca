using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Migrations
{
    /// <inheritdoc />
    public partial class ImplementazioneIngredientProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientProduct_Ingredients_IngredientsId",
                table: "IngredientProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientProduct_Products_ProductsId",
                table: "IngredientProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientProduct",
                table: "IngredientProduct");

            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "IngredientProduct",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "IngredientsId",
                table: "IngredientProduct",
                newName: "IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientProduct_ProductsId",
                table: "IngredientProduct",
                newName: "IX_IngredientProduct_ProductId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "IngredientProduct",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientProduct",
                table: "IngredientProduct",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientProduct_IngredientId",
                table: "IngredientProduct",
                column: "IngredientId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientProduct_Ingredients_IngredientId",
                table: "IngredientProduct",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientProduct_Products_ProductId",
                table: "IngredientProduct",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientProduct_Ingredients_IngredientId",
                table: "IngredientProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientProduct_Products_ProductId",
                table: "IngredientProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientProduct",
                table: "IngredientProduct");

            migrationBuilder.DropIndex(
                name: "IX_IngredientProduct_IngredientId",
                table: "IngredientProduct");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "IngredientProduct");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "IngredientProduct",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "IngredientId",
                table: "IngredientProduct",
                newName: "IngredientsId");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientProduct_ProductId",
                table: "IngredientProduct",
                newName: "IX_IngredientProduct_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientProduct",
                table: "IngredientProduct",
                columns: new[] { "IngredientsId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientProduct_Ingredients_IngredientsId",
                table: "IngredientProduct",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientProduct_Products_ProductsId",
                table: "IngredientProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
