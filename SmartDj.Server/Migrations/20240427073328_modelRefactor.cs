using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartDj.Server.Migrations
{
    /// <inheritdoc />
    public partial class modelRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Played",
                table: "SongRequests",
                newName: "WasPlayed");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WasPlayed",
                table: "SongRequests",
                newName: "Played");
        }
    }
}
