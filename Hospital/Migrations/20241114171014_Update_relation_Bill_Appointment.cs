using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hospital.Migrations
{
    /// <inheritdoc />
    public partial class Update_relation_Bill_Appointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_billings_billingId",
                table: "appointments");

            migrationBuilder.DropIndex(
                name: "IX_appointments_billingId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "billingId",
                table: "appointments");

            migrationBuilder.AddColumn<int>(
                name: "AppointmentId",
                table: "billings",
                type: "int",
                nullable: false,
                defaultValue: 0);

          

            migrationBuilder.AddForeignKey(
                name: "FK_billings_appointments_AppointmentId",
                table: "billings",
                column: "AppointmentId",
                principalTable: "appointments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billings_appointments_AppointmentId",
                table: "billings");

            migrationBuilder.DropIndex(
                name: "IX_billings_AppointmentId",
                table: "billings");

            migrationBuilder.DropColumn(
                name: "AppointmentId",
                table: "billings");

            migrationBuilder.AddColumn<int>(
                name: "billingId",
                table: "appointments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_appointments_billingId",
                table: "appointments",
                column: "billingId",
                unique: true,
                filter: "[billingId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_billings_billingId",
                table: "appointments",
                column: "billingId",
                principalTable: "billings",
                principalColumn: "Id");
        }
    }
}
