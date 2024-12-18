using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class CommitHistoryToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CommitHistoryId",
                table: "Tasks",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_CommitHistoryId",
                table: "Tasks",
                column: "CommitHistoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_CommitHistory_CommitHistoryId",
                table: "Tasks",
                column: "CommitHistoryId",
                principalTable: "CommitHistory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_CommitHistory_CommitHistoryId",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_CommitHistoryId",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "CommitHistoryId",
                table: "Tasks");
        }
    }
}
