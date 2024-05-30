using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControlePecasWeb_v0.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Peca",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Seg = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Medida = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Peca", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Pneu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Seg = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Medida = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Pneu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Equip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Modelo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Desc = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Horimetro = table.Column<float>(type: "real", nullable: true),
                    PneuId = table.Column<int>(type: "int", nullable: false),
                    PecaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Equip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Equip_Tb_Peca_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Tb_Peca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Equip_Tb_Pneu_PneuId",
                        column: x => x.PneuId,
                        principalTable: "Tb_Pneu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Oficina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EquipId = table.Column<int>(type: "int", nullable: false),
                    PneuId = table.Column<int>(type: "int", nullable: false),
                    PecaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Oficina", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Oficina_Tb_Equip_EquipId",
                        column: x => x.EquipId,
                        principalTable: "Tb_Equip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Oficina_Tb_Peca_PecaId",
                        column: x => x.PecaId,
                        principalTable: "Tb_Peca",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Oficina_Tb_Pneu_PneuId",
                        column: x => x.PneuId,
                        principalTable: "Tb_Pneu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Oficina_Tb_User_UserId",
                        column: x => x.UserId,
                        principalTable: "Tb_User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Equip_PecaId",
                table: "Tb_Equip",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Equip_PneuId",
                table: "Tb_Equip",
                column: "PneuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Oficina_EquipId",
                table: "Tb_Oficina",
                column: "EquipId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Oficina_PecaId",
                table: "Tb_Oficina",
                column: "PecaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Oficina_PneuId",
                table: "Tb_Oficina",
                column: "PneuId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Oficina_UserId",
                table: "Tb_Oficina",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Oficina");

            migrationBuilder.DropTable(
                name: "Tb_Equip");

            migrationBuilder.DropTable(
                name: "Tb_User");

            migrationBuilder.DropTable(
                name: "Tb_Peca");

            migrationBuilder.DropTable(
                name: "Tb_Pneu");
        }
    }
}
