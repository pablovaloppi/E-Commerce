using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Test.Migrations
{
    public partial class RelacionCursoUsuario3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuario_Cursos_CursosId",
                table: "CursoUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_CursoUsuario_Usuarios_UsuariosId",
                table: "CursoUsuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CursoUsuario",
                table: "CursoUsuario");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Cursos");

            migrationBuilder.RenameColumn(
                name: "UsuariosId",
                table: "CursoUsuario",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "CursosId",
                table: "CursoUsuario",
                newName: "CursoId");

            migrationBuilder.RenameIndex(
                name: "IX_CursoUsuario_UsuariosId",
                table: "CursoUsuario",
                newName: "IX_CursoUsuario_UsuarioId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "CursoUsuario",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoUsuario",
                table: "CursoUsuario",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CursoUsuario_CursoId",
                table: "CursoUsuario",
                column: "CursoId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_CursoUsuario_CursoId",
                table: "CursoUsuario");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CursoUsuario");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "CursoUsuario",
                newName: "UsuariosId");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "CursoUsuario",
                newName: "CursosId");

            migrationBuilder.RenameIndex(
                name: "IX_CursoUsuario_UsuarioId",
                table: "CursoUsuario",
                newName: "IX_CursoUsuario_UsuariosId");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Cursos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CursoUsuario",
                table: "CursoUsuario",
                columns: new[] { "CursosId", "UsuariosId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuario_Cursos_CursosId",
                table: "CursoUsuario",
                column: "CursosId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CursoUsuario_Usuarios_UsuariosId",
                table: "CursoUsuario",
                column: "UsuariosId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
