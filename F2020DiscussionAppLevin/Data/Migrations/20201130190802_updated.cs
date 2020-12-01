using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppLevin.Data.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundforRequest");

            migrationBuilder.AddColumn<string>(
                name: "FundName",
                table: "Fund",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "FundCriteria",
                columns: table => new
                {
                    FundCriteriaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientLocatoin = table.Column<string>(nullable: true),
                    PetGender = table.Column<string>(nullable: true),
                    Petsize = table.Column<string>(nullable: true),
                    PetType = table.Column<string>(nullable: true),
                    FundID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundCriteria", x => x.FundCriteriaID);
                    table.ForeignKey(
                        name: "FK_FundCriteria_Fund_FundID",
                        column: x => x.FundID,
                        principalTable: "Fund",
                        principalColumn: "FundID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FundforVoucher",
                columns: table => new
                {
                    FundforVoucherID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountAssigned = table.Column<double>(nullable: false),
                    RequestID = table.Column<int>(nullable: false),
                    FundID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundforVoucher", x => x.FundforVoucherID);
                    table.ForeignKey(
                        name: "FK_FundforVoucher_Fund_FundID",
                        column: x => x.FundID,
                        principalTable: "Fund",
                        principalColumn: "FundID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FundforVoucher_VoucherRequest_RequestID",
                        column: x => x.RequestID,
                        principalTable: "VoucherRequest",
                        principalColumn: "RequestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FundCriteria_FundID",
                table: "FundCriteria",
                column: "FundID");

            migrationBuilder.CreateIndex(
                name: "IX_FundforVoucher_FundID",
                table: "FundforVoucher",
                column: "FundID");

            migrationBuilder.CreateIndex(
                name: "IX_FundforVoucher_RequestID",
                table: "FundforVoucher",
                column: "RequestID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FundCriteria");

            migrationBuilder.DropTable(
                name: "FundforVoucher");

            migrationBuilder.DropColumn(
                name: "FundName",
                table: "Fund");

            migrationBuilder.CreateTable(
                name: "FundforRequest",
                columns: table => new
                {
                    FundforRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountAssigned = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundforRequest", x => x.FundforRequestID);
                });
        }
    }
}
