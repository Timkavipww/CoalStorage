using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pickets_Areas_AreaId",
                table: "Pickets");

           

            migrationBuilder.DropIndex(
                name: "IX_Pickets_AreaId",
                table: "Pickets");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Pickets");

            migrationBuilder.DropColumn(
                name: "Load",
                table: "Pickets");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "MainStorages");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "MainStorages");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "MainStorages");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "MainStorages");

            migrationBuilder.AddColumn<double>(
                name: "TotalLoad",
                table: "Areas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "AreaPickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "AreaPickets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "AreaPickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "AreaPickets",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalLoad",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AreaPickets");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AreaPickets");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AreaPickets");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AreaPickets");

            migrationBuilder.AddColumn<long>(
                name: "AreaId",
                table: "Pickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "Load",
                table: "Pickets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "MainStorages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "MainStorages",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "MainStorages",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "MainStorages",
                type: "text",
                nullable: true);

            

            migrationBuilder.CreateIndex(
                name: "IX_Pickets_AreaId",
                table: "Pickets",
                column: "AreaId");

        


            migrationBuilder.AddForeignKey(
                name: "FK_Pickets_Areas_AreaId",
                table: "Pickets",
                column: "AreaId",
                principalTable: "Areas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
