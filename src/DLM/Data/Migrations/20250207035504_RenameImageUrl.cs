using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DLM.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Courses",
                newName: "ImageUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Courses",
                newName: "Image");
        }
    }
}
