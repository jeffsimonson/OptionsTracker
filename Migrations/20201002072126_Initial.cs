using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OptionsTracker.Migrations
{
    public partial class Initial : Migration
    {

        protected override void Up(MigrationBuilder migrationBuilder)
        {

           migrationBuilder.CreateTable(
                name: "Market",
                columns: table => new
                {
                    MarketID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    PointValue = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    QuoteStyle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Market", x => x.MarketID);
                });

            migrationBuilder.CreateTable(
                name: "Trade",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Market = table.Column<string>(nullable: true),
                    ContractMonth = table.Column<string>(nullable: true),
                    ContractType = table.Column<string>(nullable: true),
                    StrikePrice = table.Column<string>(nullable: true),
                    ExpirationDate = table.Column<DateTime>(nullable: false),
                    EntryDate = table.Column<DateTime>(nullable: false),
                    NbrOfContracts = table.Column<int>(nullable: false),
                    EntryPrice = table.Column<decimal>(type: "decimal(18, 5)", nullable: false),
                    CurrentPrice = table.Column<decimal>(type: "decimal(18, 5)", nullable: false),
                    CommissionFees = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ExitDate = table.Column<DateTime>(nullable: true),
                    ExitPrice = table.Column<decimal>(type: "decimal(18, 5)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trade", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Market");

            migrationBuilder.DropTable(
                name: "Trade");
        }
    }
}
