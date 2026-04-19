using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cantask.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectStats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "GrowthRate",
                table: "Projects",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<double>(
                name: "Vitality",
                table: "Projects",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vitality",
                table: "Projects");

            migrationBuilder.AlterColumn<int>(
                name: "GrowthRate",
                table: "Projects",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");
        }
    }
}
