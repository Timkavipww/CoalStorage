using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations;

/// <inheritdoc />
public partial class initAddLoadTo : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_AreaPickets_PicketId",
            table: "AreaPickets");

        migrationBuilder.DropColumn(
            name: "TotalLoad",
            table: "Areas");

        migrationBuilder.AddColumn<long>(
            name: "AreaPicketId",
            table: "Pickets",
            type: "bigint",
            nullable: false,
            defaultValue: 0L);

        migrationBuilder.AddColumn<double>(
            name: "Load",
            table: "AreaPickets",
            type: "double precision",
            nullable: false,
            defaultValue: 0.0);

        migrationBuilder.CreateIndex(
            name: "IX_AreaPickets_PicketId",
            table: "AreaPickets",
            column: "PicketId",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropIndex(
            name: "IX_AreaPickets_PicketId",
            table: "AreaPickets");

        migrationBuilder.DropColumn(
            name: "AreaPicketId",
            table: "Pickets");

        migrationBuilder.DropColumn(
            name: "Load",
            table: "AreaPickets");

        migrationBuilder.AddColumn<double>(
            name: "TotalLoad",
            table: "Areas",
            type: "double precision",
            nullable: false,
            defaultValue: 0.0);

        migrationBuilder.CreateIndex(
            name: "IX_AreaPickets_PicketId",
            table: "AreaPickets",
            column: "PicketId");
    }
}
