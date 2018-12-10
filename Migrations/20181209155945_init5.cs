using Microsoft.EntityFrameworkCore.Migrations;

namespace homework.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PruductID",
                table: "Orders",
                newName: "PruductIDPId");

            migrationBuilder.RenameColumn(
                name: "Members",
                table: "Orders",
                newName: "MembersUId");

            migrationBuilder.AlterColumn<string>(
                name: "PruductIDPId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MembersUId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "PruductIDPId",
                table: "Orders",
                newName: "PruductID");

            migrationBuilder.RenameColumn(
                name: "MembersUId",
                table: "Orders",
                newName: "Members");

            migrationBuilder.AlterColumn<string>(
                name: "PruductID",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Members",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
