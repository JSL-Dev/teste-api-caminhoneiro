using Microsoft.EntityFrameworkCore.Migrations;

namespace JSL.DDD.Repository.Migrations
{
    public partial class Forekeys_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorista_Caminhao_CaminhaoId",
                table: "Motorista");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorista_Endereco_EnderecoId",
                table: "Motorista");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Motorista",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CaminhaoId",
                table: "Motorista",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorista_Caminhao_CaminhaoId",
                table: "Motorista",
                column: "CaminhaoId",
                principalTable: "Caminhao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorista_Endereco_EnderecoId",
                table: "Motorista",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motorista_Caminhao_CaminhaoId",
                table: "Motorista");

            migrationBuilder.DropForeignKey(
                name: "FK_Motorista_Endereco_EnderecoId",
                table: "Motorista");

            migrationBuilder.AlterColumn<int>(
                name: "EnderecoId",
                table: "Motorista",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CaminhaoId",
                table: "Motorista",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Motorista_Caminhao_CaminhaoId",
                table: "Motorista",
                column: "CaminhaoId",
                principalTable: "Caminhao",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Motorista_Endereco_EnderecoId",
                table: "Motorista",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
