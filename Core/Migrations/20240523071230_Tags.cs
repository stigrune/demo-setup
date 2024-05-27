using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Migrations
{
    /// <inheritdoc />
    public partial class Tags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTagEntity_Products_ProductEntityId",
                table: "ProductTagEntity");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTagEntity",
                table: "ProductTagEntity");

            migrationBuilder.RenameTable(
                name: "ProductTagEntity",
                newName: "ProductTags");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTagEntity_ProductEntityId",
                table: "ProductTags",
                newName: "IX_ProductTags_ProductEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTags_Products_ProductEntityId",
                table: "ProductTags",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTags_Products_ProductEntityId",
                table: "ProductTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTags",
                table: "ProductTags");

            migrationBuilder.RenameTable(
                name: "ProductTags",
                newName: "ProductTagEntity");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTags_ProductEntityId",
                table: "ProductTagEntity",
                newName: "IX_ProductTagEntity_ProductEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTagEntity",
                table: "ProductTagEntity",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTagEntity_Products_ProductEntityId",
                table: "ProductTagEntity",
                column: "ProductEntityId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
