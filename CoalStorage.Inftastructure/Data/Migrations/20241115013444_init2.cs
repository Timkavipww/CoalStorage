using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicketName",
                table: "Pickets");

            migrationBuilder.RenameColumn(
                name: "AreaName",
                table: "Areas",
                newName: "AreaRange");

            migrationBuilder.AddColumn<double>(
                name: "Load",
                table: "Pickets",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Load",
                table: "Pickets");

            migrationBuilder.RenameColumn(
                name: "AreaRange",
                table: "Areas",
                newName: "AreaName");

            migrationBuilder.AddColumn<string>(
                name: "PicketName",
                table: "Pickets",
                type: "text",
                nullable: true);
        }
    }
}
