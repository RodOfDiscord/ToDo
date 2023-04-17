using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace To_Do.Migrations
{
    /// <inheritdoc />
    public partial class addIsReadyfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReady",
                table: "Tasks",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReady",
                table: "Tasks");
        }
    }
}
