using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppLevin.Data.Migrations
{
    public partial class volunteerForVR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "VoulenteerID",
                table: "VoucherRequest",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherRequest_VoulenteerID",
                table: "VoucherRequest",
                column: "VoulenteerID");

            migrationBuilder.AddForeignKey(
                name: "FK_VoucherRequest_AspNetUsers_VoulenteerID",
                table: "VoucherRequest",
                column: "VoulenteerID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VoucherRequest_AspNetUsers_VoulenteerID",
                table: "VoucherRequest");

            migrationBuilder.DropIndex(
                name: "IX_VoucherRequest_VoulenteerID",
                table: "VoucherRequest");

            migrationBuilder.DropColumn(
                name: "VoulenteerID",
                table: "VoucherRequest");
        }
    }
}
