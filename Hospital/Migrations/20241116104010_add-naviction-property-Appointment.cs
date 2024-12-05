using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class addnavictionpropertyAppointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "nurses");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "billings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
