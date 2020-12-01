using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppLevin.Data.Migrations
{
    public partial class updated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FundCriteria_Fund_FundID",
                table: "FundCriteria");

            migrationBuilder.AlterColumn<int>(
                name: "FundID",
                table: "FundCriteria",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FundCriteriaID",
                table: "Fund",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fund_FundCriteriaID",
                table: "Fund",
                column: "FundCriteriaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Fund_FundCriteria_FundCriteriaID",
                table: "Fund",
                column: "FundCriteriaID",
                principalTable: "FundCriteria",
                principalColumn: "FundCriteriaID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FundCriteria_Fund_FundID",
                table: "FundCriteria",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "FundID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fund_FundCriteria_FundCriteriaID",
                table: "Fund");

            migrationBuilder.DropForeignKey(
                name: "FK_FundCriteria_Fund_FundID",
                table: "FundCriteria");

            migrationBuilder.DropIndex(
                name: "IX_Fund_FundCriteriaID",
                table: "Fund");

            migrationBuilder.DropColumn(
                name: "FundCriteriaID",
                table: "Fund");

            migrationBuilder.AlterColumn<int>(
                name: "FundID",
                table: "FundCriteria",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_FundCriteria_Fund_FundID",
                table: "FundCriteria",
                column: "FundID",
                principalTable: "Fund",
                principalColumn: "FundID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
