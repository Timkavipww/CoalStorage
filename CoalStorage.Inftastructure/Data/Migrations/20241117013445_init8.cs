using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoalStorage.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class init8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
