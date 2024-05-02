using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace testeLogico2.Migrations
{
    /// <inheritdoc />
    public partial class CreateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Condutor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condutor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedagio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Preco = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedagio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CondutorId = table.Column<Guid>(type: "uuid", nullable: false),
                    PedagioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Contador = table.Column<int>(type: "integer", nullable: false),
                    MesAtual = table.Column<int>(type: "integer", nullable: false),
                    AnoAtual = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()"),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passagem_Condutor_CondutorId",
                        column: x => x.CondutorId,
                        principalTable: "Condutor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passagem_Pedagio_PedagioId",
                        column: x => x.PedagioId,
                        principalTable: "Pedagio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_CondutorId",
                table: "Passagem",
                column: "CondutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PedagioId",
                table: "Passagem",
                column: "PedagioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagem");

            migrationBuilder.DropTable(
                name: "Condutor");

            migrationBuilder.DropTable(
                name: "Pedagio");
        }
    }
}
