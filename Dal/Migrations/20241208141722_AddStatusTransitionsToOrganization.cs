using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dal.Migrations
{
    /// <inheritdoc />
    public partial class AddStatusTransitionsToOrganization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OrganizationId",
                table: "StatusTransition",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_StatusTransition_OrganizationId",
                table: "StatusTransition",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_StatusTransition_Organizations_OrganizationId",
                table: "StatusTransition",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StatusTransition_Organizations_OrganizationId",
                table: "StatusTransition");

            migrationBuilder.DropIndex(
                name: "IX_StatusTransition_OrganizationId",
                table: "StatusTransition");

            migrationBuilder.DropColumn(
                name: "OrganizationId",
                table: "StatusTransition");
        }
    }
}
