using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockExchange.DAL.Migrations
{
    public partial class updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exchanges",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exchanges", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StockSymbols",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompanyName = table.Column<string>(type: "TEXT", nullable: false),
                    Ticker = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExchangeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockSymbols", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StockSymbols_Exchanges_ExchangeId",
                        column: x => x.ExchangeId,
                        principalTable: "Exchanges",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EodPrices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ClosePrice = table.Column<float>(type: "REAL", nullable: false),
                    StockSymbolId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EodPrices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EodPrices_StockSymbols_StockSymbolId",
                        column: x => x.StockSymbolId,
                        principalTable: "StockSymbols",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exchanges",
                columns: new[] { "ID", "IsActive", "Name" },
                values: new object[] { 1, true, "The New York Stock Exchange" });

            migrationBuilder.InsertData(
                table: "Exchanges",
                columns: new[] { "ID", "IsActive", "Name" },
                values: new object[] { 2, true, "NASDAQ Stock Exchange" });

            migrationBuilder.InsertData(
                table: "Exchanges",
                columns: new[] { "ID", "IsActive", "Name" },
                values: new object[] { 3, false, "Bombay Stock Exchange" });

            migrationBuilder.InsertData(
                table: "StockSymbols",
                columns: new[] { "ID", "CompanyName", "ExchangeId", "IsActive", "Ticker" },
                values: new object[] { 1, "Straton Oakmount", 1, false, new DateTime(2022, 9, 1, 10, 19, 56, 270, DateTimeKind.Local).AddTicks(1181) });

            migrationBuilder.InsertData(
                table: "StockSymbols",
                columns: new[] { "ID", "CompanyName", "ExchangeId", "IsActive", "Ticker" },
                values: new object[] { 2, "Apple", 2, true, new DateTime(2022, 9, 1, 10, 19, 56, 270, DateTimeKind.Local).AddTicks(1190) });

            migrationBuilder.InsertData(
                table: "StockSymbols",
                columns: new[] { "ID", "CompanyName", "ExchangeId", "IsActive", "Ticker" },
                values: new object[] { 3, "Alphabet", 3, true, new DateTime(2022, 9, 1, 10, 19, 56, 270, DateTimeKind.Local).AddTicks(1197) });

            migrationBuilder.InsertData(
                table: "EodPrices",
                columns: new[] { "ID", "ClosePrice", "Date", "StockSymbolId" },
                values: new object[] { 1, 10.14f, new DateTime(2022, 9, 1, 10, 19, 56, 270, DateTimeKind.Local).AddTicks(1238), 1 });

            migrationBuilder.InsertData(
                table: "EodPrices",
                columns: new[] { "ID", "ClosePrice", "Date", "StockSymbolId" },
                values: new object[] { 2, 20.14f, new DateTime(2022, 9, 1, 10, 19, 56, 270, DateTimeKind.Local).AddTicks(1245), 2 });

            migrationBuilder.InsertData(
                table: "EodPrices",
                columns: new[] { "ID", "ClosePrice", "Date", "StockSymbolId" },
                values: new object[] { 3, 30.14f, new DateTime(2022, 9, 1, 10, 19, 56, 270, DateTimeKind.Local).AddTicks(1251), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_EodPrices_StockSymbolId",
                table: "EodPrices",
                column: "StockSymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_StockSymbols_ExchangeId",
                table: "StockSymbols",
                column: "ExchangeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EodPrices");

            migrationBuilder.DropTable(
                name: "StockSymbols");

            migrationBuilder.DropTable(
                name: "Exchanges");
        }
    }
}
