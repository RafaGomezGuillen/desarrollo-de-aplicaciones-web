using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GomezRafael_Musica.Migrations
{
    public partial class InitialCreate:Migration
    {
        protected override void Up (MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "ArtistId", "Description", "Title", "Value" },
                values: new object[] { 1, 155, "Esto es una crítica al artista 155", "Crítica al artista 155", 1 });

            migrationBuilder.InsertData(
                table: "Review",
                columns: new[] { "Id", "ArtistId", "Description", "Title", "Value" },
                values: new object[] { 2, 212, "Esto es una crítica al artista 212", "Crítica al artista 212", 5 });
        }

        protected override void Down (MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Review");
        }
    }
}
