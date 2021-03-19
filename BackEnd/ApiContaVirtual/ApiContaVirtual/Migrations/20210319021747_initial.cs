using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiContaVirtual.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    IdConta = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "varchar(150)", nullable: false),
                    Saldo = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.IdConta);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimentacao",
                columns: table => new
                {
                    IdTipoMovimentacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimentacao", x => x.IdTipoMovimentacao);
                });

            migrationBuilder.CreateTable(
                name: "Movimentacao",
                columns: table => new
                {
                    IdMovimentacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContaIdConta = table.Column<int>(nullable: true),
                    IdConta = table.Column<int>(nullable: false),
                    TipoMovimentacaoIdTipoMovimentacao = table.Column<int>(nullable: true),
                    IdTipoMovimentacao = table.Column<int>(nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    SaldoAnterior = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    SaldoPosterior = table.Column<decimal>(type: "DECIMAL(15,2)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: true),
                    DataMovimentacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimentacao", x => x.IdMovimentacao);
                    table.ForeignKey(
                        name: "FK_Movimentacao_Conta_ContaIdConta",
                        column: x => x.ContaIdConta,
                        principalTable: "Conta",
                        principalColumn: "IdConta",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movimentacao_TipoMovimentacao_TipoMovimentacaoIdTipoMovimentacao",
                        column: x => x.TipoMovimentacaoIdTipoMovimentacao,
                        principalTable: "TipoMovimentacao",
                        principalColumn: "IdTipoMovimentacao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Conta",
                columns: new[] { "IdConta", "NomeCliente", "Saldo" },
                values: new object[] { 1, "Renato Fiorezze Silva", 0m });

            migrationBuilder.InsertData(
                table: "TipoMovimentacao",
                columns: new[] { "IdTipoMovimentacao", "Descricao" },
                values: new object[] { 1, "Crédito" });

            migrationBuilder.InsertData(
                table: "TipoMovimentacao",
                columns: new[] { "IdTipoMovimentacao", "Descricao" },
                values: new object[] { 2, "Débito" });

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_ContaIdConta",
                table: "Movimentacao",
                column: "ContaIdConta");

            migrationBuilder.CreateIndex(
                name: "IX_Movimentacao_TipoMovimentacaoIdTipoMovimentacao",
                table: "Movimentacao",
                column: "TipoMovimentacaoIdTipoMovimentacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movimentacao");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "TipoMovimentacao");
        }
    }
}
