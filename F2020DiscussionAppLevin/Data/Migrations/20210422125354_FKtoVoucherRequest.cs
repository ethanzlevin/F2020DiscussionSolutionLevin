using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppLevin.Data.Migrations
{
    public partial class FKtoVoucherRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VetClinicID",
                table: "VoucherRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherRequest_VetClinicID",
                table: "VoucherRequest",
                column: "VetClinicID");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherRequest_VetClinic_VetClinicID",
                table: "VoucherRequest",
                column: "VetClinicID",
                principalTable: "VetClinic",
                principalColumn: "VetClinicID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherRequest_VetClinic_VetClinicID",
                table: "VoucherRequest");

            migrationBuilder.DropIndex(
                name: "IX_VoucherRequest_VetClinicID",
                table: "VoucherRequest");

            migrationBuilder.DropColumn(
                name: "VetClinicID",
                table: "VoucherRequest");
        }
    }
}
