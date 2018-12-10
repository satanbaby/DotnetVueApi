using Microsoft.EntityFrameworkCore.Migrations;

namespace homework.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Members_MembersUId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Pruducts_PruductIDPId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MembersUId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PruductIDPId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MembersUId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PruductIDPId",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "OrderOId",
                table: "Pruducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderOId",
                table: "Members",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pruducts_OrderOId",
                table: "Pruducts",
                column: "OrderOId");

            migrationBuilder.CreateIndex(
                name: "IX_Members_OrderOId",
                table: "Members",
                column: "OrderOId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Orders_OrderOId",
                table: "Members",
                column: "OrderOId",
                principalTable: "Orders",
                principalColumn: "OId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pruducts_Orders_OrderOId",
                table: "Pruducts",
                column: "OrderOId",
                principalTable: "Orders",
                principalColumn: "OId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Orders_OrderOId",
                table: "Members");

            migrationBuilder.DropForeignKey(
                name: "FK_Pruducts_Orders_OrderOId",
                table: "Pruducts");

            migrationBuilder.DropIndex(
                name: "IX_Pruducts_OrderOId",
                table: "Pruducts");

            migrationBuilder.DropIndex(
                name: "IX_Members_OrderOId",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "OrderOId",
                table: "Pruducts");

            migrationBuilder.DropColumn(
                name: "OrderOId",
                table: "Members");

            migrationBuilder.AddColumn<string>(
                name: "MembersUId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PruductIDPId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MembersUId",
                table: "Orders",
                column: "MembersUId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PruductIDPId",
                table: "Orders",
                column: "PruductIDPId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Members_MembersUId",
                table: "Orders",
                column: "MembersUId",
                principalTable: "Members",
                principalColumn: "UId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Pruducts_PruductIDPId",
                table: "Orders",
                column: "PruductIDPId",
                principalTable: "Pruducts",
                principalColumn: "PId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
