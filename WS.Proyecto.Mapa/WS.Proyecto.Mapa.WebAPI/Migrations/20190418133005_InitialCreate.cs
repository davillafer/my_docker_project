using Microsoft.EntityFrameworkCore.Migrations;

namespace WS.Proyecto.Mapa.WebAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Petitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false).Annotation("Sqlite:Autoincrement", false),
                    Latitude = table.Column<double>(nullable: true),
                    Longitude = table.Column<double>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    BoardGame = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Petitions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Petitions",
                columns: new[] { "Id", "Latitude", "Longitude", "Username", "BoardGame" },
                values: new object[] { 0, 40.495341, -4.551394, "damian", "usmFRWCFjI" });

            migrationBuilder.InsertData(
                table: "Petitions",
                columns: new[] { "Id", "Latitude", "Longitude", "Username", "BoardGame" },
                values: new object[] { 1, 43.495341, -5.271394, "david", "usmFRWCFjI" });

            migrationBuilder.InsertData(
                table: "Petitions",
                columns: new[] { "Id", "Latitude", "Longitude", "Username", "BoardGame" },
                values: new object[] { 2, 43.425341, -5.571394, "pablo", "ZdHlXy4uxe" });

            migrationBuilder.InsertData(
                table: "Petitions",
                columns: new[] { "Id", "Latitude", "Longitude", "Username", "BoardGame" },
                values: new object[] { 3, 43.395341, -5.550094, "damian", "KpKepc41At" });

            migrationBuilder.InsertData(
                table: "Petitions",
                columns: new[] { "Id", "Latitude", "Longitude", "Username", "BoardGame" },
                values: new object[] { 4, 43.540349, -5.67555, "pablo", "usmFRWCFjI" });

            migrationBuilder.InsertData(
                table: "Petitions",
                columns: new[] { "Id", "Latitude", "Longitude", "Username", "BoardGame" },
                values: new object[] { 5, 43.268881, -6.711394, "pablo", "KpKepc41At" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Petitions");
        }
    }
}
