using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class chang : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "schedules",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "prescriptions",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "nurses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "billings",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "schedules");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "prescriptions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "patients");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "nurses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "billings");
        }
    }
}
