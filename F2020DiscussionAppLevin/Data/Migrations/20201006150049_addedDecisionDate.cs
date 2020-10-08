using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace F2020DiscussionAppLevin.Data.Migrations
{
    public partial class addedDecisionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DecisionDate",
                table: "VoucherRequest",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DecisionDate",
                table: "VoucherRequest");
        }
    }
}
