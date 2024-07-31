using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Esercizio_Settiminale_S7_Vescio_Pia_Francesca.Migrations
{
    /// <inheritdoc />
    public partial class creazioneRelazione : Migration
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

            migrationBuilder.RenameTable(
                name: "IngredientProduct",
                newName: "IngredientsProduct");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientProduct_ProductsId",
                table: "IngredientsProduct",
                newName: "IX_IngredientsProduct_ProductsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IngredientsProduct",
                table: "IngredientsProduct",
                columns: new[] { "IngredientsId", "ProductsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsProduct_Ingredients_IngredientsId",
                table: "IngredientsProduct",
                column: "IngredientsId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientsProduct_Products_ProductsId",
                table: "IngredientsProduct",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsProduct_Ingredients_IngredientsId",
                table: "IngredientsProduct");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientsProduct_Products_ProductsId",
                table: "IngredientsProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IngredientsProduct",
                table: "IngredientsProduct");

            migrationBuilder.RenameTable(
                name: "IngredientsProduct",
                newName: "IngredientProduct");

            migrationBuilder.RenameIndex(
                name: "IX_IngredientsProduct_ProductsId",
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
