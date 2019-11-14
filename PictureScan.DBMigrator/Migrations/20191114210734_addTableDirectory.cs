using Microsoft.EntityFrameworkCore.Migrations;

namespace PictureScan.DBMigrator.Migrations
{
    public partial class addTableDirectory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FileDirectory",
                table: "Picture");

            migrationBuilder.AddColumn<int>(
                name: "DirectoryId",
                table: "Picture",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Directory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileDirectory = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Picture_DirectoryId",
                table: "Picture",
                column: "DirectoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Picture_Directory_DirectoryId",
                table: "Picture",
                column: "DirectoryId",
                principalTable: "Directory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Picture_Directory_DirectoryId",
                table: "Picture");

            migrationBuilder.DropTable(
                name: "Directory");

            migrationBuilder.DropIndex(
                name: "IX_Picture_DirectoryId",
                table: "Picture");

            migrationBuilder.DropColumn(
                name: "DirectoryId",
                table: "Picture");

            migrationBuilder.AddColumn<string>(
                name: "FileDirectory",
                table: "Picture",
                type: "varchar(max)",
                nullable: true);
        }
    }
}
