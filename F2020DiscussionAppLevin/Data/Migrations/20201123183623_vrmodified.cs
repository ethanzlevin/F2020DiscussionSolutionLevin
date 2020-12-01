using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppLevin.Data.Migrations
{
    public partial class vrmodified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RequestAmount",
                table: "VoucherRequest",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "VoucherRedeemed",
                table: "VoucherRequest",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fund",
                columns: table => new
                {
                    FundID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentFundAmount = table.Column<double>(nullable: false),
                    FundType = table.Column<string>(nullable: false),
                    OriginalFundAmount = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fund", x => x.FundID);
                });

            migrationBuilder.CreateTable(
                name: "FundforRequest",
                columns: table => new
                {
                    FundforRequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountAssigned = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundforRequest", x => x.FundforRequestID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fund");

            migrationBuilder.DropTable(
                name: "FundforRequest");

            migrationBuilder.DropColumn(
                name: "RequestAmount",
                table: "VoucherRequest");

            migrationBuilder.DropColumn(
                name: "VoucherRedeemed",
                table: "VoucherRequest");
        }
    }
}
