using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevoraLimeArena.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArenaEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArenaEntities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FighterEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<int>(type: "INTEGER", nullable: false),
                    ArenaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FighterEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FighterEntities_ArenaEntities_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "ArenaEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FightRoundEntities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArenaId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoundNr = table.Column<int>(type: "INTEGER", nullable: false),
                    AttackerName = table.Column<string>(type: "TEXT", nullable: false),
                    DefenderName = table.Column<string>(type: "TEXT", nullable: false),
                    HealthChangeAttacker = table.Column<int>(type: "INTEGER", nullable: false),
                    HealthChangedDefender = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalHealthAttacker = table.Column<int>(type: "INTEGER", nullable: false),
                    FinalHealthDefender = table.Column<int>(type: "INTEGER", nullable: false),
                    IsAttackerDead = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDefenderDead = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FightRoundEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FightRoundEntities_ArenaEntities_ArenaId",
                        column: x => x.ArenaId,
                        principalTable: "ArenaEntities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FighterEntities_ArenaId",
                table: "FighterEntities",
                column: "ArenaId");

            migrationBuilder.CreateIndex(
                name: "IX_FightRoundEntities_ArenaId",
                table: "FightRoundEntities",
                column: "ArenaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FighterEntities");

            migrationBuilder.DropTable(
                name: "FightRoundEntities");

            migrationBuilder.DropTable(
                name: "ArenaEntities");
        }
    }
}
