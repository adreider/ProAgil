using Microsoft.EntityFrameworkCore.Migrations;

namespace ProAgil.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enventos",
                columns: table => new
                {
                    id = table.Column<string>(nullable: false),
                    Local = table.Column<string>(nullable: true),
                    DataEvento = table.Column<string>(nullable: true),
                    Tema = table.Column<string>(nullable: true),
                    QtdPessoas = table.Column<int>(nullable: false),
                    Lote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enventos", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enventos");
        }
    }
}
