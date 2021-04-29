using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppLevin.Data.Migrations
{
    public partial class spelling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundforVoucher_Fund_FundID",
                table: "FundforVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_FundforVoucher_VoucherRequest_RequestID",
                table: "FundforVoucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundforVoucher",
                table: "FundforVoucher");

            migrationBuilder.DropColumn(
                name: "ClientLocatoin",
                table: "FundCriteria");

            migrationBuilder.RenameTable(
                name: "FundforVoucher",
                newName: "FundForVoucher");

            migrationBuilder.RenameIndex(
                name: "IX_FundforVoucher_RequestID",
                table: "FundForVoucher",
                newName: "IX_FundForVoucher_RequestID");

            migrationBuilder.RenameIndex(
                name: "IX_FundforVoucher_FundID",
                table: "FundForVoucher",
                newName: "IX_FundForVoucher_FundID");

            migrationBuilder.RenameColumn(
                name: "Petsize",
                table: "FundCriteria",
                newName: "PetSize");

            migrationBuilder.AddColumn<string>(
                name: "ClientLocation",
                table: "FundCriteria",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundForVoucher",
                table: "FundForVoucher",
                column: "FundforVoucherID");

            migrationBuilder.AddForeignKey(
                name: "FK_FundForVoucher_Fund_FundID",
                table: "FundForVoucher",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "FundID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundForVoucher_VoucherRequest_RequestID",
                table: "FundForVoucher",
                column: "RequestID",
                principalTable: "VoucherRequest",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundForVoucher_Fund_FundID",
                table: "FundForVoucher");

            migrationBuilder.DropForeignKey(
                name: "FK_FundForVoucher_VoucherRequest_RequestID",
                table: "FundForVoucher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FundForVoucher",
                table: "FundForVoucher");

            migrationBuilder.DropColumn(
                name: "ClientLocation",
                table: "FundCriteria");

            migrationBuilder.RenameTable(
                name: "FundForVoucher",
                newName: "FundforVoucher");

            migrationBuilder.RenameIndex(
                name: "IX_FundForVoucher_RequestID",
                table: "FundforVoucher",
                newName: "IX_FundforVoucher_RequestID");

            migrationBuilder.RenameIndex(
                name: "IX_FundForVoucher_FundID",
                table: "FundforVoucher",
                newName: "IX_FundforVoucher_FundID");

            migrationBuilder.RenameColumn(
                name: "PetSize",
                table: "FundCriteria",
                newName: "Petsize");

            migrationBuilder.AddColumn<string>(
                name: "ClientLocatoin",
                table: "FundCriteria",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FundforVoucher",
                table: "FundforVoucher",
                column: "FundforVoucherID");

            migrationBuilder.AddForeignKey(
                name: "FK_FundforVoucher_Fund_FundID",
                table: "FundforVoucher",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "FundID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FundforVoucher_VoucherRequest_RequestID",
                table: "FundforVoucher",
                column: "RequestID",
                principalTable: "VoucherRequest",
                principalColumn: "RequestID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
