using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MainStorages",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StorageName = table.Column<string>(type: "text", nullable: true),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainStorages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AreaName = table.Column<string>(type: "text", nullable: true),
                    MainStorageId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_MainStorages_MainStorageId",
                        column: x => x.MainStorageId,
                        principalTable: "MainStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pickets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PicketName = table.Column<string>(type: "text", nullable: true),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    MainStorageId = table.Column<long>(type: "bigint", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pickets_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pickets_MainStorages_MainStorageId",
                        column: x => x.MainStorageId,
                        principalTable: "MainStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MainStorageCargos",
                columns: table => new
                {
                    MainStorageId = table.Column<long>(type: "bigint", nullable: false),
                    AreaId = table.Column<long>(type: "bigint", nullable: false),
                    PicketId = table.Column<long>(type: "bigint", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainStorageCargos", x => new { x.MainStorageId, x.AreaId, x.PicketId });
                    table.ForeignKey(
                        name: "FK_MainStorageCargos_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainStorageCargos_MainStorages_MainStorageId",
                        column: x => x.MainStorageId,
                        principalTable: "MainStorages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MainStorageCargos_Pickets_PicketId",
                        column: x => x.PicketId,
                        principalTable: "Pickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_MainStorageId",
                table: "Areas",
                column: "MainStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_MainStorageCargos_AreaId",
                table: "MainStorageCargos",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_MainStorageCargos_PicketId",
                table: "MainStorageCargos",
                column: "PicketId");

            migrationBuilder.CreateIndex(
                name: "IX_Pickets_AreaId",
                table: "Pickets",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pickets_MainStorageId",
                table: "Pickets",
                column: "MainStorageId");

         
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainStorageCargos");

            migrationBuilder.DropTable(
                name: "Pickets");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "MainStorages");
        }
    }
}
