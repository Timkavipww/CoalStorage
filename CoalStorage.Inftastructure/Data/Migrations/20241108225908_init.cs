using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoalStorage.Inftastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Created = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    LastModified = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MainStorageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Storages_MainStorageId",
                        column: x => x.MainStorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Area = table.Column<int>(type: "integer", nullable: false),
                    AreaId = table.Column<int>(type: "integer", nullable: true),
                    MainStorageId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pickets_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pickets_Storages_MainStorageId",
                        column: x => x.MainStorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PicketAreas",
                columns: table => new
                {
                    PicketID = table.Column<int>(type: "integer", nullable: false),
                    AreaID = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PicketAreas", x => new { x.PicketID, x.AreaID });
                    table.ForeignKey(
                        name: "FK_PicketAreas_Areas_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PicketAreas_Pickets_PicketID",
                        column: x => x.PicketID,
                        principalTable: "Pickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoragePickets",
                columns: table => new
                {
                    StorageID = table.Column<int>(type: "integer", nullable: false),
                    PicketID = table.Column<int>(type: "integer", nullable: false),
                    Id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoragePickets", x => new { x.StorageID, x.PicketID });
                    table.ForeignKey(
                        name: "FK_StoragePickets_Pickets_PicketID",
                        column: x => x.PicketID,
                        principalTable: "Pickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StoragePickets_Storages_StorageID",
                        column: x => x.StorageID,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_MainStorageId",
                table: "Areas",
                column: "MainStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_PicketAreas_AreaID",
                table: "PicketAreas",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Pickets_AreaId",
                table: "Pickets",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pickets_MainStorageId",
                table: "Pickets",
                column: "MainStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_StoragePickets_PicketID",
                table: "StoragePickets",
                column: "PicketID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PicketAreas");

            migrationBuilder.DropTable(
                name: "StoragePickets");

            migrationBuilder.DropTable(
                name: "Pickets");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}
