using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class RelacionCursoUsuario4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuario_Cursos_CursoId",
                table: "CursoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuario_Usuarios_UsuarioId",
                table: "CursoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursoUsuario",
                table: "CursoUsuario");

            migrationBuilder.RenameTable(
                name: "CursoUsuario",
                newName: "CursosUsuarios");

            migrationBuilder.RenameIndex(
                name: "IX_CursoUsuario_UsuarioId",
                table: "CursosUsuarios",
                newName: "IX_CursosUsuarios_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_CursoUsuario_CursoId",
                table: "CursosUsuarios",
                newName: "IX_CursosUsuarios_CursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursosUsuarios",
                table: "CursosUsuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CursosUsuarios_Cursos_CursoId",
                table: "CursosUsuarios",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursosUsuarios_Usuarios_UsuarioId",
                table: "CursosUsuarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursosUsuarios_Cursos_CursoId",
                table: "CursosUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_CursosUsuarios_Usuarios_UsuarioId",
                table: "CursosUsuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursosUsuarios",
                table: "CursosUsuarios");

            migrationBuilder.RenameTable(
                name: "CursosUsuarios",
                newName: "CursoUsuario");

            migrationBuilder.RenameIndex(
                name: "IX_CursosUsuarios_UsuarioId",
                table: "CursoUsuario",
                newName: "IX_CursoUsuario_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_CursosUsuarios_CursoId",
                table: "CursoUsuario",
                newName: "IX_CursoUsuario_CursoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoUsuario",
                table: "CursoUsuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuario_Cursos_CursoId",
                table: "CursoUsuario",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuario_Usuarios_UsuarioId",
                table: "CursoUsuario",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
