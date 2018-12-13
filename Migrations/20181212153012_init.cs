using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace homework.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Account = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Account);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    UId = table.Column<string>(nullable: false),
                    UPwd = table.Column<string>(nullable: true),
                    UName = table.Column<string>(nullable: true),
                    RegisterTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Pruducts",
                columns: table => new
                {
                    PId = table.Column<string>(nullable: false),
                    PName = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Qty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pruducts", x => x.PId);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OId = table.Column<string>(nullable: false),
                    orderQty = table.Column<int>(nullable: false),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    MembersUId = table.Column<string>(nullable: true),
                    PruductIDPId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OId);
                    table.ForeignKey(
                        name: "FK_Orders_Members_MembersUId",
                        column: x => x.MembersUId,
                        principalTable: "Members",
                        principalColumn: "UId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Pruducts_PruductIDPId",
                        column: x => x.PruductIDPId,
                        principalTable: "Pruducts",
                        principalColumn: "PId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MembersUId",
                table: "Orders",
                column: "MembersUId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PruductIDPId",
                table: "Orders",
                column: "PruductIDPId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Pruducts");
        }
    }
}
