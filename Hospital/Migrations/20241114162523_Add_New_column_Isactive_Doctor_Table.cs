using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class Add_New_column_Isactive_Doctor_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "doctors");
        }
    }
}
