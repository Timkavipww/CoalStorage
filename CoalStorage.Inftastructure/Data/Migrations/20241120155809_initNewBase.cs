using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class initNewBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pickets_MainStorages_MainStorageId",
                table: "Pickets");

            migrationBuilder.DropTable(
                name: "AreaPickets");

            migrationBuilder.DropColumn(
                name: "AreaPicketId",
                table: "Pickets");

            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "Areas");

            migrationBuilder.RenameColumn(
                name: "MainStorageId",
                table: "Pickets",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Pickets_MainStorageId",
                table: "Pickets",
                newName: "IX_Pickets_AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pickets_Areas_AreaId",
                table: "Pickets",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pickets_Areas_AreaId",
                table: "Pickets");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Pickets",
                newName: "MainStorageId");

            migrationBuilder.RenameIndex(
                name: "IX_Pickets_AreaId",
                table: "Pickets",
                newName: "IX_Pickets_MainStorageId");

            migrationBuilder.AddColumn<long>(
                name: "AreaPicketId",
                table: "Pickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "Areas",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AreaPickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    PicketId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true),
                    Load = table.Column<double>(type: "double precision", nullable: false)
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
                column: "PicketId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pickets_MainStorages_MainStorageId",
                table: "Pickets",
                column: "MainStorageId",
                principalTable: "MainStorages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
