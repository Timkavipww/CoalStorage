using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class initNewBase16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicketName",
                table: "Pickets");

            migrationBuilder.DropColumn(
                name: "TotalLoad",
                table: "Areas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PicketName",
                table: "Pickets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<double>(
                name: "TotalLoad",
                table: "Areas",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
