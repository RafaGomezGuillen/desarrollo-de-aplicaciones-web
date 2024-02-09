using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PO01_GomezRafael_v1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recomendacion",
                columns: table => new
                {
                    RecomendacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(160)", maxLength: 160, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    Estacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CodigoProducto = table.Column<int>(type: "int", nullable: false),
                    ProductoCodigoProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recomendacion", x => x.RecomendacionId);
                    table.ForeignKey(
                        name: "FK_Recomendacion_producto_ProductoCodigoProducto",
                        column: x => x.ProductoCodigoProducto,
                        principalTable: "producto",
                        principalColumn: "codigo_producto");
                });

            migrationBuilder.InsertData(
                table: "Recomendacion",
                columns: new[] { "RecomendacionId", "CodigoProducto", "Descripcion", "Estacion", "ProductoCodigoProducto", "Title" },
                values: new object[] { 1, 132, "Description", "Primavera", null, "Title AR-010" });

            migrationBuilder.InsertData(
                table: "Recomendacion",
                columns: new[] { "RecomendacionId", "CodigoProducto", "Descripcion", "Estacion", "ProductoCodigoProducto", "Title" },
                values: new object[] { 2, 179, "Description Aromatica", "Primavera", null, "Title AR-009" });

            migrationBuilder.CreateIndex(
                name: "IX_Recomendacion_ProductoCodigoProducto",
                table: "Recomendacion",
                column: "ProductoCodigoProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recomendacion");
        }
    }
}
