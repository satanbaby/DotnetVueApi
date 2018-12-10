using Microsoft.EntityFrameworkCore.Migrations;

namespace homework.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Member",
                table: "Orders",
                newName: "MembersUId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Members_MembersUId",
                table: "Orders",
                column: "MembersUId",
                principalTable: "Members",
                principalColumn: "UId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Members_MembersUId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MembersUId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "MembersUId",
                table: "Orders",
                newName: "Member");

            migrationBuilder.AlterColumn<string>(
                name: "Member",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
