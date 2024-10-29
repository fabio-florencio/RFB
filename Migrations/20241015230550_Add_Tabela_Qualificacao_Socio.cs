using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RFB.Migrations
{
    /// <inheritdoc />
    public partial class Add_Tabela_Qualificacao_Socio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QualificacoesSocios",
                columns: table => new
                {
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificacoesSocios", x => x.Codigo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QualificacoesSocios");
        }
    }
}
