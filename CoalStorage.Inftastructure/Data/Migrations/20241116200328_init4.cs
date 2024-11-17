using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaPickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    PicketId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaPickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaPickets_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaPickets_Pickets_PicketId",
                        column: x => x.PicketId,
                        principalTable: "Pickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaPickets_AreaId",
                table: "AreaPickets",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaPickets_PicketId",
                table: "AreaPickets",
                column: "PicketId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaPickets");
        }
    }
}
