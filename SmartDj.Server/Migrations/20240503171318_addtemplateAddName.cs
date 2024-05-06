using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDj.Server.Migrations
{
    /// <inheritdoc />
    public partial class addtemplateAddName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FormTemplates",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "FormTemplates");
        }
    }
}
