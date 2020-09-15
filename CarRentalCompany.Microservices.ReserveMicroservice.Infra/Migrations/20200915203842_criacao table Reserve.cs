using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRentalCompany.Microservices.ReserveMicroservice.Infra.Migrations
{
    public partial class criacaotableReserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoneyValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserves",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarId = table.Column<Guid>(nullable: false),
                    ActionType = table.Column<int>(nullable: false),
                    RentalDate = table.Column<DateTime>(nullable: false),
                    DevolutionDate = table.Column<DateTime>(nullable: false),
                    ValueId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reserves_MoneyValues_ValueId",
                        column: x => x.ValueId,
                        principalTable: "MoneyValues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_ValueId",
                table: "Reserves",
                column: "ValueId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reserves");

            migrationBuilder.DropTable(
                name: "MoneyValues");
        }
    }
}
