using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class RelacionPaisUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Cursos_CursoId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Usuarios",
                newName: "PaisId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_CursoId",
                table: "Usuarios",
                newName: "IX_Usuarios_PaisId");

            migrationBuilder.CreateTable(
                name: "Pais",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pais", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Pais_PaisId",
                table: "Usuarios",
                column: "PaisId",
                principalTable: "Pais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Pais_PaisId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Pais");

            migrationBuilder.RenameColumn(
                name: "PaisId",
                table: "Usuarios",
                newName: "CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_PaisId",
                table: "Usuarios",
                newName: "IX_Usuarios_CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Cursos_CursoId",
                table: "Usuarios",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
