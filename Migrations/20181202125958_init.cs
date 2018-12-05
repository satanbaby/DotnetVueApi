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
                    UName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.UId);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OId = table.Column<string>(nullable: false),
                    Member = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OId);
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
                name: "orders",
                columns: table => new
                {
                    pid = table.Column<string>(nullable: false),
                    Qty = table.Column<int>(nullable: false),
                    OrderOId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.pid);
                    table.ForeignKey(
                        name: "FK_orders_Order_OrderOId",
                        column: x => x.OrderOId,
                        principalTable: "Order",
                        principalColumn: "OId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_OrderOId",
                table: "orders",
                column: "OrderOId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "Pruducts");

            migrationBuilder.DropTable(
                name: "Order");
        }
    }
}
